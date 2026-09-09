# Tutorial: come chiedere l'integrazione ufficiale

Questo tutorial descrive **a chi scrivere, dove entrare e in quale ordine**.
Le richieste vanno inviate in inglese usando
[`PROPOSAL_SUBMISSION_EN.md`](PROPOSAL_SUBMISSION_EN.md). Non inviare
credenziali, token o codice che usi API non autorizzate.

## Prima di iniziare

Prepara questi dati:

- nome e cognome;
- paese;
- email professionale;
- organizzazione, oppure `Independent developer`;
- link pubblico al repository o a un PDF;
- breve descrizione della tua esperienza;
- un indirizzo email al quale ricevere risposte.

Nel dossier lascia scritto chiaramente:

> The current prototype is a local .NET demonstration with a mock simulator
> adapter. It does not claim VATSIM, MSFS, or PS5 compatibility.

## Ordine corretto

| Ordine | Destinatario | Obiettivo |
| --- | --- | --- |
| 1 | VATSIM | Verificare policy, dati e modello di client |
| 2 | Microsoft/Asobo | Identificare API/SDK e forma dell'integrazione MSFS |
| 3 | Sony Interactive Entertainment | Valutare il percorso PS5 e la certificazione |

Non partire da Sony: senza un modello tecnico MSFS e una valutazione VATSIM
non potresti descrivere cosa dovrebbe essere certificato sulla console.

## Passo 1 — VATSIM

### Dove andare

1. Apri [vatsim.net](https://vatsim.net/).
2. Apri il canale **Support/Help/Contact** disponibile nel sito in quel
   momento.
3. Se il modulo propone categorie, scegli quella relativa a software,
   client, policy o supporto generale.
4. Se non trovi la categoria adatta, scrivi nel messaggio:
   `Please forward this request to the team responsible for software clients,
   integrations, and data access.`

Non usare indirizzi email trovati in vecchi forum, repository o post non
ufficiali: i recapiti possono cambiare.

### Cosa inviare

- Oggetto dalla sezione VATSIM di
  [`PROPOSAL_SUBMISSION_EN.md`](PROPOSAL_SUBMISSION_EN.md).
- Il testo VATSIM pronto nello stesso documento.
- Link a `docs/PROPOSTA_INTEGRAZIONE.md`, preferibilmente esportato in PDF.
- Nessuna credenziale VATSIM e nessun dato reale di utenti.

### Cosa chiedere

Chiedi quattro cose precise:

1. quale team deve valutare l'integrazione;
2. quali policy valgono per client e dati;
3. se esiste un percorso di review tecnica o sandbox;
4. quali requisiti servono prima di creare un adapter reale.

### Dopo l'invio

Salva numero ticket, data, portale usato e risposta in un file privato.
Aspetta una risposta o almeno un riferimento di presa in carico prima di
scrivere a Microsoft/Asobo. Se VATSIM chiede modifiche, aggiorna prima il
progetto e il dossier.

## Passo 2 — Microsoft / Asobo

### Dove andare

Usa entrambi questi percorsi:

1. [Microsoft Flight Simulator Marketplace Partner
   Program](https://flightsimulator.zendesk.com/hc/en-us/articles/360015914839-Marketplace-Partner-Program-FAQ).
   Nella sezione **How do I sign up?** apri il link di candidatura.
2. [Microsoft Developer Gaming](https://developer.microsoft.com/en-us/games/).
   Usa il percorso partner/developer e chiedi di essere inoltrato al team
   Microsoft Flight Simulator/Asobo.

Il primo portale riguarda il programma partner Marketplace. Non significa che
il progetto sia già idoneo al Marketplace: nel messaggio chiedi prima un
confronto tecnico.

### Cosa compilare

- Nome: il tuo nome o ragione sociale reale.
- Tipo di richiesta: partner/developer inquiry, se disponibile.
- Oggetto: quello indicato nella sezione Microsoft di
  [`PROPOSAL_SUBMISSION_EN.md`](PROPOSAL_SUBMISSION_EN.md).
- Riferimento VATSIM: numero ticket o data della risposta.
- Allegati: proposta, architettura, threat model breve.

### Cosa chiedere

Domanda esplicitamente:

- quale API o SDK ufficiale supporta il caso d'uso;
- se serve un addon, una companion app o entrambi;
- quali piattaforme e versioni MSFS sono ammesse;
- quale NDA, sandbox, programma partner e certificazione si applicano;
- se il Marketplace è un canale valido per questo prodotto.

Non descrivere il mock come integrazione funzionante e non usare “official
addon”, “supported by Microsoft” o “PS5 compatible”.

### Dopo l'invio

Conserva il ticket Microsoft/Asobo. Se il team indica un SDK o un programma
partner, implementa soltanto quanto documentato e autorizzato. Non iniziare
reverse engineering se la risposta è negativa o incompleta.

## Passo 3 — Sony

### Quando inviare

Invia la richiesta solo dopo avere:

- un riscontro VATSIM sul modello di client e dati;
- un riscontro Microsoft/Asobo su API/SDK e architettura;
- una descrizione concreta di ciò che dovrebbe eseguire o collegare PS5.

### Dove andare

1. Apri [PlayStation Partners](https://partners.playstation.net/).
2. Crea o usa l'account dell'organizzazione, se richiesto.
3. Completa i dati legali richiesti.
4. Presenta una **partner inquiry** per una valutazione di integrazione PS5.
5. Chiedi il percorso corretto per NDA, networking, sandbox e certificazione.

Non chiedere di installare liberamente il server .NET sulla console: il
modello dovrà essere definito da Sony e dagli altri titolari.

### Cosa allegare

- proposta tecnica;
- riferimenti ai ticket VATSIM e Microsoft/Asobo;
- diagramma con dati in ingresso e uscita dalla console;
- threat model;
- dichiarazione: `PS5 is not supported at this stage`.

## Checklist finale

Prima di premere **Submit**:

- [ ] il testo è in inglese;
- [ ] hai sostituito tutti i campi `[between brackets]`;
- [ ] hai usato il portale ufficiale aperto dal sito del destinatario;
- [ ] non hai allegato password, token o dati personali;
- [ ] hai dichiarato che il prototipo usa un mock adapter;
- [ ] hai dichiarato che PS5 non è supportata;
- [ ] hai salvato screenshot, data e numero ticket;
- [ ] non hai usato marchi o frasi che implicano approvazione.

## Se non ricevi risposta

Dopo un periodo ragionevole, invia **un solo follow-up** nello stesso ticket,
citando numero e data della richiesta. Non aprire molte richieste duplicate e
non cercare di aggirare il canale ufficiale tramite contatti personali.

## Cosa significa una risposta positiva

Una risposta positiva al ticket non equivale automaticamente ad approvazione
commerciale o certificazione. Prima di dichiarare supporto ufficiale devono
esistere, secondo il caso:

- autorizzazione scritta;
- API/SDK e condizioni d'uso;
- programma partner o NDA;
- test e criteri di certificazione;
- approvazione della build e del canale di distribuzione.
