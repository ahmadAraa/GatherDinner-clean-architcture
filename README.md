# Gather Dinner

Gather Dinner is a backend API for organizing dinner get-togethers: creating events, inviting guests, and managing RSVPs.

The primary purpose of this project is to practice Clean Architecture in ASP.NET Core, along with design patterns such as CQRS and Mediator.

## Goals

- Structure an ASP.NET Core solution using Clean Architecture, with clear separation between Domain, Application, Infrastructure, and Presentation layers
- Implement CQRS (Command Query Responsibility Segregation) to separate reads from writes
- Use the Mediator pattern (via [MediatR](https://github.com/jbogard/MediatR)) to decouple request handling from controllers
- Apply supporting patterns: Repository, Unit of Work, dependency injection, result-based error handling, and validation pipelines

## Architecture

The solution follows Clean Architecture, split across five projects:

```
GatherDinner
├── GatherDinner.Domain           # Entities, value objects, domain rules
├── GatherDinner.Application      # Use cases (CQRS commands/queries), handlers, validators
│   └── Authentication
│       ├── Commands
│       │   └── Register          # RegisterCommand, RegisterCommandHandler, RegisterCommandValidator
│       ├── Queries
│       └── Common
├── GatherDinner.Contracts        # Request/response models shared between Api and Application
├── GatherDinner.Infrastructure   # Implementations of Application interfaces (currently in-memory)
└── GatherDinner.Api
    ├── Controllers                # ApiController, AuthenticationController
    ├── Mapping                    # AuthenticationMappingConfig
    ├── DependancyInjection.cs
    └── Program.cs
```

**Dependency rule:** Domain has no dependencies. Application depends only on Domain. Contracts and Infrastructure depend on Application (and implement its interfaces). Api depends on all of the above and wires everything up at startup — never the other way around.

## Tech Stack

- **.NET 10** / ASP.NET Core Web API
- **MediatR** — Mediator pattern for CQRS commands/queries
- **FluentValidation** — request validation pipeline
- **ErrorOr** — error handling without exceptions
- Persistence is in-memory for now; EF Core is planned for a later stage

No automated tests yet.

## Key Patterns in Use

| Pattern | Where it's used |
|---|---|
| **CQRS** | Commands and Queries are split into separate folders per feature, e.g. `Application/Authentication/Commands/Register` and `Application/Authentication/Queries` |
| **Mediator** | Controllers send a single `IMediator.Send(...)` call — no direct handler references |
| **Result/Error handling** | Handlers return `ErrorOr<T>` instead of throwing exceptions for expected failures |
| **Validation** | Each command has a matching `Validator` (e.g. `RegisterCommandValidator`) |

Repository/Unit of Work is not implemented yet — persistence is in-memory for now.

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Setup

```bash
git clone <repo-url>
cd GatherDinner

dotnet restore
dotnet run --project GatherDinner.Api
```

No database setup is required yet since persistence is currently in-memory.

## Core Features (planned/in progress)

- [ ] Create a dinner event (date, location, host)
- [ ] Invite guests to an event
- [ ] Guests can RSVP (yes / no / maybe)
- [ ] View upcoming events and guest lists
- [ ] Update/cancel an event

## Learning Notes

Use this section to record implementation notes as the project develops — for example, decisions made around CQRS handlers, validation, or error handling now, and notes on EF Core integration once persistence is added later.

## License

MIT (or your license of choice)
