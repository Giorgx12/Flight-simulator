# Integration proposal submission package

This document contains English text ready to paste into official forms or
emails. **It does not send any message automatically.** Replace all bracketed
placeholders before submitting and use only the recipient's current official
portal or support channel.

## Recommended order

1. **VATSIM** — validate the use case, data requirements, and client model.
2. **Microsoft/Asobo** — define the official MSFS API/SDK and integration
   model.
3. **Sony Interactive Entertainment** — evaluate the PS5 path after the
   technical requirements are understood.

Do not use the Marketplace as the first technical contact, and do not send
the same undifferentiated request to all three organizations.

## 1. First submission: VATSIM

### Where to submit

Use the support channel or official form published at
[vatsim.net](https://vatsim.net/). If the form does not provide a suitable
category, ask to be forwarded to the team responsible for software clients,
integrations, and data access. Do not use email addresses copied from old
posts or unofficial repositories.

### Subject

`Technical discussion request: VATSIM integration with Microsoft Flight Simulator`

### Ready-to-send message

> Hello,  
>  
> I am preparing a technical proposal for an integration between an authorized
> VATSIM client and Microsoft Flight Simulator. Before contacting
> Microsoft/Asobo and Sony, I would like to confirm with VATSIM that the use
> case and client model are compatible with your policies and network
> requirements.  
>  
> The project is currently a local prototype. It uses no private APIs, no
> reverse engineering, and contains no VATSIM credentials. It exposes only a
> localhost protocol and uses a mock simulator adapter. It does not claim
> compatibility with VATSIM, MSFS, or PS5.  
>  
> Could you please advise:
> 1. which department or contact should evaluate this type of software
>    integration;
> 2. which rules apply to clients, traffic data, authentication, and
>    distribution;
> 3. whether an official technical review or sandbox process exists;
> 4. which requirements must be met before implementing a production adapter.
>  
> I can provide a technical proposal, architecture diagram, and mock-only
> demonstration without real account data.  
>  
> Kind regards,  
> Giorgio Bridarolli  
> Independent developer  
> giorgiobridarolli@gmail.com  
> Italy  
> https://github.com/Giorgx12/Flight-simulator

## 2. Second submission: Microsoft/Asobo

Send this **only after receiving a VATSIM response or ticket**. Use the
[Microsoft Flight Simulator Marketplace Partner
Program](https://flightsimulator.zendesk.com/hc/en-us/articles/360015914839-Marketplace-Partner-Program-FAQ)
and the [Microsoft Developer Gaming
portal](https://developer.microsoft.com/en-us/games/). If the selected form
is not appropriate, explicitly ask to be routed to the Microsoft Flight
Simulator/Asobo team.

### Subject

`Technical partner inquiry: VATSIM integration for Microsoft Flight Simulator`

### Ready-to-send message

> Hello,  
>  
> We are evaluating an official integration between an authorized VATSIM
> client and Microsoft Flight Simulator. VATSIM has been contacted to review
> the client model and data requirements. Reference: `[VATSIM ticket or reply,
> if available]`.  
>  
> We are not requesting access to private APIs and do not use reverse
> engineering. The current prototype is a local .NET companion application
> with a mock simulator adapter. It exists only to demonstrate protocol,
> connection management, and security boundaries.  
>  
> We would like to understand:
> - which official API or SDK could support this use case;
> - whether the product should be an MSFS package, companion application, or
>   both;
> - which platforms and simulator versions could be supported;
> - which partner program, NDA, sandbox, and certification process apply;
> - whether the Marketplace is an appropriate distribution channel.
>  
> We will not claim MSFS compatibility or use Microsoft/Asobo branding before
> receiving written authorization.  
>  
> Kind regards,  
> Giorgio Bridarolli, Independent developer, giorgiobridarolli@gmail.com,
> Italy, https://github.com/Giorgx12/Flight-simulator

## 3. Third submission: Sony

Send this **only after the Microsoft/Asobo technical model is understood**.
Use the [PlayStation Partners
Portal](https://partners.playstation.net/). Present this as a request to
evaluate an approved PS5 integration, not as a request to freely install a
.NET server on the console.

### Subject

`PlayStation 5 partner inquiry: evaluation of an approved MSFS/VATSIM integration`

### Ready-to-send message

> Hello,  
>  
> We would like to be directed to the appropriate process for evaluating an
> approved integration between Microsoft Flight Simulator, an authorized
> VATSIM client, and PlayStation 5. Microsoft/Asobo has been contacted to
> clarify APIs, SDKs, and the integration model. Reference: `[ticket or reply]`.
> VATSIM has been contacted regarding network policies and data requirements.
> Reference: `[ticket or reply]`.  
>  
> We do not intend to install unauthorized software on the console, bypass
> sandbox restrictions, or use private APIs. We are requesting guidance on the
> partner program, execution and networking model, permitted data, NDA
> requirements, and certification process.  
>  
> The current prototype is only a local .NET demonstration with a mock
> simulator adapter and does not claim PS5 support.  
>  
> Kind regards,  
> Giorgio Bridarolli, Independent developer, giorgiobridarolli@gmail.com,
> Italy, https://github.com/Giorgx12/Flight-simulator

## Non-confidential attachments

Initially provide only:

- `docs/PROPOSTA_INTEGRAZIONE.md` translated or exported as a PDF;
- architecture and data-flow diagram;
- short threat model;
- capability and permissions matrix, defaulting to read-only;
- repository or proposal link with no secrets;
- references to responses or tickets from previous contacts.

Do not attach passwords, tokens, VATSIM credentials, user personal data,
binaries containing unauthorized APIs, or confidential third-party material.

## Complete before sending

- full name or legal entity;
- country of residence or incorporation;
- professional email;
- public website or profile;
- technical experience summary;
- legal and technical contact;
- repository or PDF link;
- initial target platform: **PC**;
- explicit statement: **PS5 is not supported at this stage**.
