# Practical .NET Roadmap for 2026

> 🌍 Available in Persian: [README فارسی](fa-version/README.md)

**The only guide you need to go from zero to job-ready .NET developer.**

No fluff. No random technology lists. Just a clear path that mirrors how real developers build real applications.

---

## What's Inside

### [The Full Roadmap](docs/roadmap.md)
The complete step-by-step guide covering:
- 8 progressive steps from first API to production deployment
- MUST vs OPTIONAL classification for every technology
- Real-world architecture thinking
- 7 portfolio projects with extension ideas
- A 12-week learning plan
- What NOT to learn (saves you months)
- Honest advice on getting your first .NET job

### [Companion Code Templates](templates/)
Production-ready starter code:
- [Program.cs](templates/Program.cs) - Minimal production-ready setup
- [Endpoints](templates/Endpoints/TaskEndpoints.cs) - Full CRUD API with Minimal APIs
- [DbContext](templates/Data/AppDbContext.cs) - EF Core with proper entity configuration
- [DI Registration](templates/DependencyInjection.cs) - Clean service registration
- [Dockerfile](templates/Dockerfile) - Multi-stage, Alpine-based, non-root
- [docker-compose.yml](templates/docker-compose.yml) - Full local dev stack
- [CI/CD Pipeline](templates/.github/workflows/ci.yml) - GitHub Actions
- [appsettings.json](templates/appsettings.json) - Structured config with Serilog

**Code Examples:**
- [Logging](templates/Examples/LoggingExample.cs) - Structured logging patterns
- [Validation](templates/Examples/ValidationExample.cs) - FluentValidation setup
- [Error Handling](templates/Examples/ErrorHandlingExample.cs) - ProblemDetails + global exception handler

### [Checklists](checklists/)
Track your progress:
- [Step-by-Step Checklist](checklists/step-by-step-checklist.md) - Know exactly when you're ready to move on
- [Production Readiness](checklists/production-readiness.md) - Pre-deployment verification
- [12-Week Progress Tracker](checklists/weekly-progress.md) - Stay on track

---

## Repo Structure

```
Roadmap 2026/
│
├── README.md                          ← You are here
│
├── docs/
│   └── roadmap.md                     ← The full roadmap guide
│
├── templates/                         ← Production-ready starter code
│   ├── Program.cs                     ← App entry point with full pipeline
│   ├── DependencyInjection.cs         ← Service registration patterns
│   ├── appsettings.json               ← Configuration template
│   ├── appsettings.Development.json   ← Dev-specific overrides
│   ├── Dockerfile                     ← Multi-stage Docker build
│   ├── docker-compose.yml             ← Local dev stack (DB, Redis, Seq)
│   ├── .gitignore                     ← Standard .NET gitignore
│   │
│   ├── Endpoints/
│   │   └── TaskEndpoints.cs           ← Minimal API CRUD example
│   │
│   ├── Data/
│   │   └── AppDbContext.cs            ← EF Core context + entities
│   │
│   ├── Examples/
│   │   ├── LoggingExample.cs          ← Serilog structured logging
│   │   ├── ValidationExample.cs       ← FluentValidation patterns
│   │   └── ErrorHandlingExample.cs    ← ProblemDetails + exception handler
│   │
│   └── .github/
│       └── workflows/
│           └── ci.yml                 ← GitHub Actions CI/CD pipeline
│
├── checklists/                        ← Progress tracking
│   ├── step-by-step-checklist.md      ← Per-step completion checklist
│   ├── production-readiness.md        ← Pre-deployment checklist
│   └── weekly-progress.md             ← 12-week progress tracker
│
└── projects/                          ← Portfolio project guides
    └── README.md                      ← Project descriptions and setup
```

### What Goes Where

| Folder | Purpose |
|---|---|
| `docs/` | The roadmap document and any supplementary guides |
| `templates/` | Copy-paste starter code for real projects |
| `checklists/` | Track your learning progress and deployment readiness |
| `projects/` | Detailed guides for each portfolio project |

---

## Quick Start

1. **Read** [the roadmap](docs/roadmap.md) - understand the full journey
2. **Check** [the step 1 checklist](checklists/step-by-step-checklist.md) - know your starting point
3. **Copy** the [templates](templates/) into your first project
4. **Build** - follow the 12-week plan
5. **Track** your progress with the [weekly tracker](checklists/weekly-progress.md)

---

## The Path

```
Step 1: Build Your First API          → Weeks 1-2
Step 2: Add a Database                → Weeks 3-4
Step 3: Validation, Errors & Logging  → Weeks 5-6
Step 4: Authentication                → Weeks 7-8
Step 5: Production Readiness          → Weeks 9-10
Step 6: Background Jobs               → Week 11
Step 7: Scale & Optimize              → Week 11-12
Step 8: Testing                       → Week 12
```

Each step builds on the previous one. Don't skip ahead.

---

## Who This Is For

- **Beginners** who want a clear path into .NET backend development
- **Self-taught developers** tired of random tutorials that lead nowhere
- **Career switchers** who need to get job-ready fast
- **Junior developers** who want to fill gaps and level up

## Who This Is NOT For

- Developers looking for a comprehensive reference of every .NET technology
- Frontend developers (this is backend/API focused)
- People who want theory without practice

---

## Tech Stack (Contextual, Not Random)

These technologies are introduced **when you need them**, not as a shopping list:

| When | You'll Use |
|---|---|
| Building APIs | ASP.NET Core, Minimal APIs |
| Adding data | EF Core, PostgreSQL |
| Validating input | FluentValidation |
| Handling errors | ProblemDetails |
| Logging | Serilog |
| Authenticating | JWT, ASP.NET Core Identity |
| Deploying | Docker, GitHub Actions |
| Caching | Redis, Output Caching |
| Background work | BackgroundService, MassTransit |
| Testing | xUnit, WebApplicationFactory |
| Resilience | Polly |

---

## Contributing

Found something wrong or want to suggest an improvement? Open an issue or submit a PR.

---

## License

This roadmap is free to use, share, and adapt. If you find it helpful, share it with someone who needs it.

---

*Built by developers who've been through the journey and want to make it easier for the next generation.*
