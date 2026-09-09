# Pacchetto di invio della proposta

Questo documento contiene testi pronti da copiare nei moduli o nelle email
ufficiali. **Non invia automaticamente alcun messaggio.** Prima dell'invio
completa i campi tra parentesi quadre e usa solo il form o il portale
pubblicato dal destinatario.

## Ordine

1. **VATSIM** — validare il caso d'uso, i dati e il modello di client.
2. **Microsoft/Asobo** — definire API/SDK e forma dell'integrazione MSFS.
3. **Sony** — valutare il percorso PS5 sulla base dei requisiti già chiariti.

Non usare il Marketplace come primo contatto tecnico e non inviare la stessa
richiesta indistinta ai tre destinatari.

## 1. Primo invio: VATSIM

### Dove

Usa il canale di supporto o il modulo ufficiale pubblicato su
[vatsim.net](https://vatsim.net/). Se il modulo non individua la categoria
corretta, chiedi di essere inoltrato al referente per client software,
integrazioni e accesso ai dati. Non usare indirizzi trovati in vecchi post o
repository non ufficiali.

### Oggetto

`Richiesta di confronto tecnico: integrazione VATSIM con Microsoft Flight Simulator`

### Testo pronto

> Buongiorno,  
>  
> sto preparando una proposta tecnica per un’integrazione tra un client VATSIM
> autorizzato e Microsoft Flight Simulator. Prima di contattare Microsoft/Asobo
> e Sony, vorrei verificare con VATSIM che il caso d’uso e il modello di client
> siano compatibili con le vostre policy e con i requisiti del network.  
>  
> Il progetto è attualmente un prototipo locale, senza accesso a API private,
> senza reverse engineering e senza credenziali VATSIM incorporate. Espone
> soltanto un protocollo localhost e usa un simulatore mock. Non dichiara
> compatibilità con VATSIM, MSFS o PS5.  
>  
> Vi chiederei cortesemente:
> 1. quale dipartimento o referente deve valutare un’integrazione software di
>    questo tipo;
> 2. quali regole si applicano a client, dati di traffico, autenticazione e
>    distribuzione;
> 3. se esiste un percorso ufficiale per una valutazione tecnica o sandbox;
> 4. quali requisiti dovremmo soddisfare prima di implementare un adapter reale.
>  
> Posso fornire una proposta tecnica, un diagramma architetturale e una demo
> mock senza dati reali.  
>  
> Cordiali saluti,  
> Giorgio Bridarolli  
> Independent developer  
> giorgiobridarolli@gmail.com  
> Italy  
> https://github.com/Giorgx12/Flight-simulator

## 2. Secondo invio: Microsoft/Asobo

Invialo **solo dopo una risposta o un ticket VATSIM**. Usa il [Marketplace
Partner Program](https://flightsimulator.zendesk.com/hc/en-us/articles/360015914839-Marketplace-Partner-Program-FAQ)
e il [portale Microsoft Developer
Gaming](https://developer.microsoft.com/en-us/games/). Se il modulo non è
adatto, chiedi esplicitamente l'inoltro al team Microsoft Flight
Simulator/Asobo. Il Marketplace è un possibile canale partner, non una
garanzia che una companion app o un’integrazione di rete sia ammissibile.

### Oggetto

`Technical partner inquiry: VATSIM integration for Microsoft Flight Simulator`

### Testo pronto

> Buongiorno,  
>  
> stiamo valutando un’integrazione ufficiale tra un client VATSIM autorizzato
> e Microsoft Flight Simulator. VATSIM è stato contattato per verificare il
> modello di client e i requisiti sui dati; possiamo fornire il riferimento
> `[ticket o risposta VATSIM, se disponibile]`.  
>  
> Non chiediamo accesso a API private e non utilizziamo reverse engineering.
> Il prototipo attuale è una companion app .NET locale con adapter mock; serve
> esclusivamente a dimostrare protocollo, gestione connessioni e sicurezza.
>  
> Vorremmo sapere:
> - quale API o SDK ufficiale consente questo caso d’uso;
> - se il prodotto deve essere addon MSFS, companion app o entrambi;
> - quali piattaforme e versioni sono supportabili;
> - quale programma partner, NDA, sandbox e certificazione sono necessari;
> - se un eventuale percorso Marketplace è applicabile al prodotto.
>  
> Non dichiareremo compatibilità MSFS né useremo marchi Microsoft/Asobo prima
> di un’autorizzazione scritta.  
>  
> Cordiali saluti,  
> Giorgio Bridarolli, Independent developer, giorgiobridarolli@gmail.com,
> Italy, https://github.com/Giorgx12/Flight-simulator

## 3. Terzo invio: Sony

Invialo **solo dopo aver definito con Microsoft/Asobo il modello tecnico**.
Usa il [PlayStation Partners
Portal](https://partners.playstation.net/). La richiesta deve descrivere
un’integrazione PS5 da valutare, non un programma .NET da installare
liberamente sulla console.

### Oggetto

`PlayStation 5 partner inquiry: evaluation of an approved MSFS/VATSIM integration`

### Testo pronto

> Buongiorno,  
>  
> chiediamo di essere indirizzati al percorso corretto per valutare
> un’integrazione approvata tra Microsoft Flight Simulator, un client VATSIM
> autorizzato e PlayStation 5. Microsoft/Asobo è stato contattato per chiarire
> API, SDK e modello di integrazione; riferimento: `[ticket o risposta]`.
> VATSIM è stato contattato per policy e requisiti del network; riferimento:
> `[ticket o risposta]`.  
>  
> Non intendiamo installare software non autorizzato sulla console, eludere
> sandbox o usare API private. Chiediamo indicazioni su programma partner,
> modello di esecuzione e networking, dati consentiti, NDA e certificazione.
>  
> Il prototipo allegato è soltanto una demo locale .NET con adapter mock e non
> dichiara supporto PS5.  
>  
> Cordiali saluti,  
> Giorgio Bridarolli, Independent developer, giorgiobridarolli@gmail.com,
> Italy, https://github.com/Giorgx12/Flight-simulator

## Allegati da preparare

Invia inizialmente solo materiale non riservato:

- `docs/PROPOSTA_INTEGRAZIONE.md` esportato in PDF;
- schema architetturale e flusso dati;
- breve threat model;
- matrice delle capability richieste, con default read-only;
- link al repository senza segreti;
- riferimenti ai ticket ottenuti dai destinatari precedenti.

Non allegare password, token, credenziali VATSIM, dati personali di utenti,
binari con API non autorizzate o documentazione riservata di terzi.

## Dati da completare prima dell'invio

- nome e cognome / ragione sociale;
- paese di residenza o sede;
- email professionale;
- sito o profilo pubblico;
- descrizione dell'esperienza tecnica;
- referente legale e tecnico;
- link al repository o PDF;
- piattaforma iniziale proposta (PC);
- dichiarazione esplicita: **PS5 non supportata in questa fase**.
