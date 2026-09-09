# Percorso di pubblicazione

## Stato attuale

Il repository produce una **companion app PC sperimentale in C#/.NET**, non un
pacchetto Marketplace MSFS e non un'applicazione PS5. Il server usa API .NET
incluse nel runtime e il simulatore è rappresentato da un adapter mock. Non va
distribuito dichiarando compatibilità MSFS o VATSIM finché non esiste un
adapter basato su API ufficiali e un'approvazione dei titolari.

## Distribuzione tecnica PC

```powershell
dotnet build dotnet/VatsimMsfsBridge -c Release
dotnet publish dotnet/VatsimMsfsBridge -c Release --self-contained false
```

L'eseguibile non installa nulla in MSFS e non modifica la console. Per una
release reale occorrono installer firmato, checksum pubblici, disinstallazione
pulita, privacy policy, aggiornamenti e supporto.

## Gate prima dell'integrazione ufficiale

1. **Contratto tecnico**: identificare l'API/SDK MSFS ufficiale e definire
   dati letti e comandi consentiti.
2. **VATSIM**: verificare modello di client, autenticazione, distribuzione dati
   e requisiti del network; nessuna credenziale incorporata.
3. **Sicurezza**: threat model, allowlist, autenticazione locale, rate limit,
   validazione input, audit log minimizzati e test di disconnessione.
4. **Compatibilità**: matrice per versioni MSFS/Windows/API, test automatici,
   test manuali e piano rollback.
5. **Revisione partner**: chiedere a Microsoft/Asobo se il prodotto debba
   essere addon SDK, companion app o entrambi.
6. **Marketplace**: seguire il programma partner e la checklist corrente del
   portale ufficiale; non dichiarare approvazione prima dell'accettazione.

## PS5

Non è un semplice porting del server PC. Servono programma sviluppatori Sony,
modello di esecuzione e networking approvato, integrazione MSFS autorizzata e
certificazione console. Fino ad allora la documentazione deve indicare
“PS5 non supportata”.

## Dossier per Sony/Asobo

- diagramma componenti e confini di responsabilità;
- specifica protocollo e versionamento;
- threat model e flussi dati;
- matrice permessi read-only/write;
- piano test e aggiornamenti;
- privacy, telemetria e cancellazione dati;
- supporto, incident response e rollback;
- dichiarazione delle API ancora mancanti.
