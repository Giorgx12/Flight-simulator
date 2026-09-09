# VATSIM / MSFS Localhost Bridge (prototipo C#/.NET)

Companion app PC sperimentale per valutare un bridge tra un client VATSIM
(ad esempio swift) e Microsoft Flight Simulator. Espone un'API HTTP su
`127.0.0.1`; l'accesso al simulatore è isolato in un adapter sostituibile.
**Non è un'integrazione ufficiale Microsoft, Asobo, VATSIM o Sony e non
dichiara supporto PS5.**

## Architettura

```text
swift / altro client
        | JSON HTTP localhost, protocollo v1
BridgeService + gestione client / timeout
        | ISimulatorAdapter
MockSimulatorAdapter       [futuro: adapter MSFS autorizzato]
```

Il codice è in `dotnet/VatsimMsfsBridge/Program.cs` e usa solo API .NET
incluse nel runtime (`HttpListener`, `System.Text.Json`): nessun pacchetto
NuGet runtime e nessuna API privata del simulatore.

## Limiti reali

Su PS5 non si può presumere di installare un server .NET, raggiungere il
processo MSFS o aprire porte locali come su PC. Servirebbero programma
sviluppatori e approvazione Sony, un SDK/API MSFS ufficiale autorizzato,
accordo sui dati e termini VATSIM. L'adapter reale resta quindi da validare
con i titolari: il mock non dimostra compatibilità.

## Requisiti e avvio

- .NET SDK 8+
- Windows come target primario della companion app

Installazione rapida su Windows con `winget`:

```powershell
winget install Microsoft.DotNet.SDK.8
dotnet --version
```

Se `winget` non è disponibile, installa lo SDK 8 dal sito ufficiale
[dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0).
Serve lo **SDK**, non soltanto il Runtime.

```powershell
dotnet run --project dotnet/VatsimMsfsBridge
```

Variabili: `VATSIM_BRIDGE_HOST`, `VATSIM_BRIDGE_PORT`,
`VATSIM_BRIDGE_CLIENT_TIMEOUT`, `VATSIM_BRIDGE_LOG_LEVEL`. Il bind predefinito
è loopback, per non esporre il prototipo in LAN.

## Protocollo HTTP v1

Envelope JSON:

```json
{"protocol_version":"1","message_type":"hello","request_id":"id-1",
 "payload":{"client_id":"swift-1","client_name":"swift","client_version":"0.1"}}
```

| Metodo | Endpoint | Scopo |
| --- | --- | --- |
| GET | `/healthz` | stato del servizio e adapter |
| GET | `/v1/status` | stato mock e client attivi |
| POST | `/v1/connect` | registrazione (`hello`) |
| POST | `/v1/heartbeat` | rinnovo client |
| POST | `/v1/command` | comando autorizzato |

Il server verifica versione, tipo messaggio, endpoint e campi obbligatori.
Il mock accetta soltanto `set_heading` con `heading_deg` nell'intervallo
`[0, 360)`.

## Build e pubblicazione tecnica

```powershell
dotnet build dotnet/VatsimMsfsBridge -c Release
dotnet publish dotnet/VatsimMsfsBridge -c Release --self-contained false
```

Questo produce una companion app .NET, non un package Marketplace MSFS.
Prima di una release servono firma del codice, installer, privacy policy,
supporto, aggiornamenti, threat model e adapter basato su API autorizzate.
Il percorso per partner e Marketplace è in
[`docs/PUBBLICAZIONE.md`](docs/PUBBLICAZIONE.md).
La richiesta formale di integrazione approvata è in
[`docs/PROPOSTA_INTEGRAZIONE.md`](docs/PROPOSTA_INTEGRAZIONE.md).
Il documento indica anche a quali portali ufficiali inviare la richiesta:
non esiste un unico contatto pubblico comune a Sony, Asobo e VATSIM.
I testi pronti per i primi tre invii e la checklist degli allegati sono in
[`docs/INVIO_PROPOSTA.md`](docs/INVIO_PROPOSTA.md).
La versione inglese pronta per i destinatari internazionali è in
[`docs/PROPOSAL_SUBMISSION_EN.md`](docs/PROPOSAL_SUBMISSION_EN.md).
Il tutorial operativo passo per passo è in
[`docs/TUTORIAL_INVIO.md`](docs/TUTORIAL_INVIO.md).
