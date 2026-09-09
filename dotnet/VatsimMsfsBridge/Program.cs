using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var config = BridgeConfig.FromEnvironment();
var adapter = new MockSimulatorAdapter();
var service = new BridgeService(adapter, config.ClientTimeout);
using var server = new BridgeServer(config, service);
Console.CancelKeyPress += (_, eventArgs) =>
{
    eventArgs.Cancel = true;
    server.Stop();
};
server.Run();

public sealed record BridgeConfig(string Host, int Port, int ClientTimeout, LogLevel LogLevel)
{
    public static BridgeConfig FromEnvironment()
    {
        static int Number(string name, int fallback) =>
            int.TryParse(Environment.GetEnvironmentVariable(name), out var value) ? value : fallback;

        var level = Enum.TryParse<LogLevel>(
            Environment.GetEnvironmentVariable("VATSIM_BRIDGE_LOG_LEVEL"), true, out var parsed)
            ? parsed : LogLevel.Info;
        return new(
            Environment.GetEnvironmentVariable("VATSIM_BRIDGE_HOST") ?? "127.0.0.1",
            Number("VATSIM_BRIDGE_PORT", 8765),
            Number("VATSIM_BRIDGE_CLIENT_TIMEOUT", 30),
            level);
    }
}

public enum LogLevel { Info, Warning, Error }

public sealed class BridgeServer : IDisposable
{
    private readonly HttpListener listener = new();
    private readonly BridgeService service;
    private readonly BridgeConfig config;
    private volatile bool stopping;

    public BridgeServer(BridgeConfig config, BridgeService service)
    {
        this.config = config;
        this.service = service;
        listener.Prefixes.Add($"http://{config.Host}:{config.Port}/");
    }

    public void Run()
    {
        listener.Start();
        Log(LogLevel.Info, $"listening on http://{config.Host}:{config.Port}");
        while (!stopping)
        {
            try { Handle(listener.GetContext()); }
            catch (HttpListenerException) when (stopping) { }
            catch (Exception error) { Log(LogLevel.Error, error.Message); }
        }
    }

    public void Stop()
    {
        stopping = true;
        if (listener.IsListening) listener.Stop();
    }

    private void Handle(HttpListenerContext context)
    {
        try
        {
            var response = context.Response;
            response.Headers["Access-Control-Allow-Origin"] = "http://localhost";
            var result = context.Request.HttpMethod == "GET"
                ? HandleGet(context.Request.Url?.AbsolutePath ?? "")
                : HandlePost(context);
            Write(response, result.Status, result.Body);
        }
        catch (ProtocolException error) { Write(context.Response, 400, Error("invalid_request", error.Message)); }
        catch (Exception error)
        {
            Log(LogLevel.Error, error.ToString());
            Write(context.Response, 500, Error("internal_error", "unexpected bridge error"));
        }
    }

    private (int Status, object Body) HandleGet(string path) => path switch
    {
        "/healthz" => (200, new { status = "ok", service = service.Health() }),
        "/v1/status" => (200, service.Status()),
        _ => (404, Error("not_found", "endpoint not found"))
    };

    private (int Status, object Body) HandlePost(HttpListenerContext context)
    {
        using var reader = new StreamReader(context.Request.InputStream, Encoding.UTF8);
        var envelope = Protocol.Parse(reader.ReadToEnd());
        var path = context.Request.Url?.AbsolutePath;
        var expected = envelope.MessageType switch
        {
            "hello" => "/v1/connect",
            "heartbeat" => "/v1/heartbeat",
            "command" => "/v1/command",
            _ => ""
        };
        if (path != expected) throw new ProtocolException("message_type does not match endpoint");
        return envelope.MessageType switch
        {
            "hello" => (200, service.Register(envelope.Payload)),
            "heartbeat" => (200, service.Heartbeat(envelope.Payload)),
            "command" => (200, service.Command(envelope.Payload)),
            _ => throw new ProtocolException("unsupported message type")
        };
    }

    private static object Error(string code, string detail) => new { error = code, detail };

    private static void Write(HttpListenerResponse response, int status, object body)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(body, Json.Options);
        response.StatusCode = status;
        response.ContentType = "application/json";
        response.ContentLength64 = bytes.Length;
        using var output = response.OutputStream;
        output.Write(bytes);
    }

    private void Log(LogLevel level, string message)
    {
        if (level >= config.LogLevel) Console.Error.WriteLine($"{DateTimeOffset.UtcNow:o} {level} {message}");
    }

    public void Dispose() { Stop(); listener.Close(); }
}

public sealed class BridgeService
{
    private readonly ISimulatorAdapter adapter;
    private readonly TimeSpan timeout;
    private readonly Dictionary<string, ClientConnection> clients = new();
    private readonly object sync = new();

    public BridgeService(ISimulatorAdapter adapter, int timeoutSeconds)
    {
        this.adapter = adapter;
        timeout = TimeSpan.FromSeconds(timeoutSeconds);
    }

    public object Health() => adapter.Health();
    public object Register(Dictionary<string, JsonElement> payload)
    {
        var hello = Protocol.RequiredStrings(payload, "client_id", "client_name", "client_version");
        lock (sync) clients[hello[0]] = new ClientConnection(hello[0], hello[1], DateTimeOffset.UtcNow);
        return Protocol.Envelope("hello", new { accepted = true, client_id = hello[0], server = "vatsim-msfs-bridge" });
    }
    public object Heartbeat(Dictionary<string, JsonElement> payload)
    {
        var id = Protocol.RequiredStrings(payload, "client_id")[0];
        lock (sync)
        {
            if (!clients.ContainsKey(id)) throw new ProtocolException("unknown client_id; send hello first");
            clients[id] = clients[id] with { LastSeen = DateTimeOffset.UtcNow };
        }
        return new { status = "ok" };
    }
    public object Command(Dictionary<string, JsonElement> payload)
    {
        var id = Protocol.RequiredStrings(payload, "client_id")[0];
        if (!payload.TryGetValue("command", out var command)) throw new ProtocolException("missing field: command");
        Heartbeat(new Dictionary<string, JsonElement> { ["client_id"] = JsonDocument.Parse($"\"{id}\"").RootElement });
        return Protocol.Envelope("aircraft_state", new { client_id = id, aircraft = adapter.Apply(command) });
    }
    public object Status()
    {
        lock (sync)
        {
            var now = DateTimeOffset.UtcNow;
            foreach (var id in clients.Where(item => now - item.Value.LastSeen > timeout).Select(item => item.Key).ToList())
                clients.Remove(id);
            return new { adapter = adapter.Health(), aircraft = adapter.State(), clients = clients.Values };
        }
    }
}

public interface ISimulatorAdapter
{
    object Health();
    object State();
    object Apply(JsonElement command);
}

public sealed class MockSimulatorAdapter : ISimulatorAdapter
{
    private double heading = 90;
    public object Health() => new { adapter = "mock", connected = true };
    public object State() => new { adapter = "mock", connected = true, latitude = 41.9028, longitude = 12.4964, altitude_ft = 2500, heading_deg = heading };
    public object Apply(JsonElement command)
    {
        if (command.GetProperty("name").GetString() != "set_heading") throw new ProtocolException("mock supports set_heading only");
        var value = command.GetProperty("heading_deg").GetDouble();
        if (value < 0 || value >= 360) throw new ProtocolException("heading_deg must be in [0, 360)");
        heading = value;
        return State();
    }
}

public sealed record ClientConnection(string ClientId, string ClientName, DateTimeOffset LastSeen);
public sealed class ProtocolException(string message) : Exception(message);

public sealed record Envelope(
    [property: JsonPropertyName("protocol_version")] string ProtocolVersion,
    [property: JsonPropertyName("message_type")] string MessageType,
    [property: JsonPropertyName("payload")] Dictionary<string, JsonElement> Payload);

public static class Protocol
{
    public static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);
    private static readonly string[] Types = ["hello", "heartbeat", "command"];

    public static Envelope Parse(string json)
    {
        var value = JsonSerializer.Deserialize<Envelope>(json, Options)
            ?? throw new ProtocolException("message must be a JSON object");
        if (value.ProtocolVersion != "1") throw new ProtocolException("unsupported protocol_version");
        if (!Types.Contains(value.MessageType)) throw new ProtocolException("unsupported message_type");
        return value;
    }
    public static string[] RequiredStrings(Dictionary<string, JsonElement> payload, params string[] names)
    {
        return names.Select(name =>
        {
            if (!payload.TryGetValue(name, out var value) || value.ValueKind != JsonValueKind.String || string.IsNullOrWhiteSpace(value.GetString()))
                throw new ProtocolException($"missing or invalid field: {name}");
            return value.GetString()!;
        }).ToArray();
    }
    public static object Envelope(string type, object payload) => new { protocol_version = "1", message_type = type, request_id = Guid.NewGuid().ToString(), payload };
}
