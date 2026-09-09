# Proposta di integrazione VATSIM / Microsoft Flight Simulator

**Stato del documento:** proposta tecnica preliminare, non approvata.  
**Destinatari:** Microsoft/Asobo e Sony Interactive Entertainment.  
**Proponente:** da completare con identità legale, contatti e referenti.

## Dove inviarla

Non esiste un singolo ufficio pubblico che approvi contemporaneamente MSFS,
VATSIM e PS5. Usa questi percorsi ufficiali e conserva il numero/ricevuta di
ogni invio:

1. **Microsoft Flight Simulator Marketplace Partner Program** — presenta la
   proposta tramite [la pagina ufficiale del programma
   partner](https://flightsimulator.zendesk.com/hc/en-us/articles/360015914839-Marketplace-Partner-Program-FAQ),
   usando il link di candidatura indicato nella sezione “How do I sign up?”.
   Specifica che chiedi prima un confronto tecnico su un'integrazione e non
   stai ancora sottoponendo un prodotto Marketplace.
2. **Microsoft/Asobo developer route** — usa il [portale Microsoft
   Developer per i programmi
   gaming](https://developer.microsoft.com/en-us/games/) per il percorso
   partner/developer e allega la stessa proposta. Chiedi esplicitamente di
   essere indirizzato al team Microsoft Flight Simulator/Asobo competente.
3. **Sony Interactive Entertainment** — registra l'organizzazione nel
   [PlayStation Partners
   portal](https://partners.playstation.net/) e presenta la richiesta come
   valutazione di integrazione PS5, non come semplice app da installare sulla
   console. Il portale può richiedere account aziendale, NDA e dati legali.
4. **VATSIM** — invia una richiesta separata attraverso i canali di supporto
   e policy pubblicati su [vatsim.net](https://vatsim.net/), chiedendo il
   referente per client, dati e integrazioni software. Non usare credenziali
   VATSIM nella demo e non presentare l'approvazione VATSIM come già ottenuta.

Se un modulo non accetta allegati, invia una sintesi di una pagina con il link
al repository e chiedi il canale corretto per la documentazione tecnica. Non
spedire password, token, build con API reverse-engineered o dati personali
non necessari. I link e i programmi possono cambiare: verifica sempre la
pagina ufficiale al momento dell'invio.

## 1. Richiesta

Chiediamo un confronto tecnico e commerciale per valutare un'integrazione
ufficiale che consenta a un client VATSIM autorizzato di interoperare con
Microsoft Flight Simulator, includendo un eventuale percorso compatibile con
PlayStation 5.

Non chiediamo accesso a API private, reverse engineering o privilegi
non documentati. Chiediamo invece:

- un referente tecnico Microsoft/Asobo per identificare l'API o SDK ufficiale;
- un referente Sony per il modello di esecuzione, networking e distribuzione
  consentito su PS5;
- chiarimento sul prodotto corretto: addon MSFS, companion app, servizio
  autorizzato o combinazione di questi;
- requisiti di certificazione, sicurezza, privacy, supporto e aggiornamento;
- eventuale accesso a documentazione, sandbox, programma partner o NDA
  necessari per proseguire.

## 2. Problema e valore

VATSIM offre un ambiente online di simulazione del controllo del traffico
aereo. L'integrazione proposta mira a rendere disponibili, con consenso
dell'utente e secondo le regole VATSIM, dati e funzioni di simulazione
necessari al client autorizzato senza modificare il binario del simulatore e
senza introdurre accessi non supportati.

Il valore potenziale è:

- interoperabilità documentata e manutenibile;
- controllo centralizzato delle autorizzazioni;
- esperienza coerente tra client VATSIM e simulatore;
- telemetria e supporto gestibili secondo policy approvate;
- superficie tecnica verificabile da Microsoft/Asobo e Sony.

## 3. Architettura proposta

```text
Client VATSIM autorizzato
          |
          | protocollo versionato, autenticato e rate-limited
          v
Componente di integrazione approvato
          |
          | solo API/SDK ufficiali e capability dichiarate
          v
Microsoft Flight Simulator
          |
          +-- PC: eventuale companion app o addon SDK
          +-- PS5: componente approvato e certificato da Sony
```

Il repository contiene oggi soltanto un prototipo di protocollo localhost e un
mock adapter. Il mock non rappresenta un'API Microsoft/Asobo e non dimostra
compatibilità PS5. L'implementazione reale deve essere definita e fornita
solo dopo il contratto tecnico con i titolari.

## 4. Confini e garanzie richieste

### Fuori scope

- reverse engineering del simulatore o della console;
- lettura/scrittura di memoria o injection nel processo;
- bypass di sandbox, certificati o DRM;
- uso di endpoint non pubblici senza autorizzazione;
- distribuzione di credenziali VATSIM nel client;
- dichiarazione di supporto PS5 prima della certificazione.

### Garanzie progettuali

- principio del minimo privilegio e capability negotiation;
- allowlist esplicita per ogni dato letto o comando inviato;
- default read-only fino ad approvazione diversa;
- bind locale e autenticazione tra componenti;
- rate limiting, timeout, retry controllati e comportamento sicuro offline;
- log tecnici minimizzati, senza credenziali o dati personali non necessari;
- aggiornamenti firmati, rollback e compatibilità versionata;
- audit trail e processo di risposta agli incidenti.

## 5. Domande per Microsoft/Asobo

1. Quale SDK/API ufficiale consente l'accesso ai dati di posizione, stato e
   traffico necessari al caso d'uso?
2. È ammessa una companion app esterna? Con quale canale IPC o networking?
3. Quali funzioni possono essere read-only e quali richiedono approvazione
   ulteriore?
4. Il prodotto deve essere distribuito come package MSFS, applicazione
   separata, Marketplace item o altro?
5. Quali versioni di MSFS, PC e console possono essere supportate?
6. Quali test, firma, certificazione e obblighi di supporto sono richiesti?

## 6. Domande per Sony

1. È previsto un modello approvato per un'integrazione di rete tra PS5,
   MSFS e un servizio/companion autorizzato?
2. Dove dovrebbe essere eseguito il componente: console, PC associato o
   servizio remoto?
3. Quali API di rete, sandbox, autenticazione e storage sono disponibili?
4. Quale programma partner e quale processo di certificazione si applicano?
5. Quali dati possono lasciare la console e quali telemetrie sono consentite?

## 7. Piano di collaborazione richiesto

### Fase A — Discovery riservata

Condividere questa proposta, il diagramma, il threat model e una demo mock.
Nessuna demo deve usare API non autorizzate o dati reali di account.

### Fase B — Specifica congiunta

Definire schema dati, capability, autenticazione, lifecycle, errori,
compatibilità, ownership del supporto e criteri di rifiuto sicuro.

### Fase C — Sandbox autorizzata

Implementare l'adapter soltanto contro l'ambiente, SDK e credenziali
concessi. Eseguire test di carico, disconnessione, aggiornamento e sicurezza.

### Fase D — Certificazione e pilota

Sottoporre build firmate ai processi indicati da Microsoft/Asobo e Sony,
eseguire un pilota limitato e pubblicare solo le piattaforme formalmente
approvate.

## 8. Allegati da preparare

- identità legale, azienda e referenti;
- privacy policy e data-flow diagram;
- threat model e security response plan;
- specifica del protocollo v1;
- matrice capability e permessi;
- piano test e compatibilità;
- modello di aggiornamento e rollback;
- demo mock senza API proprietarie;
- piano di supporto e SLA proposti.

## Dichiarazione

Questa proposta non implica endorsement, partnership, compatibilità o
approvazione da parte di Sony, Microsoft, Asobo o VATSIM. Nomi, marchi e
servizi restano dei rispettivi titolari. Ogni integrazione reale è
subordinata a autorizzazione scritta, API/SDK concessi e certificazione
applicabile.
