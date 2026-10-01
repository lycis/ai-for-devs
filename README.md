# AI for Developers

Hands-on training materials for developers who want to understand modern AI, use coding assistants effectively, and build their own AI agents.

The course emphasizes engineering judgment: provide useful context, work in small steps, review generated code, and verify results. When building agents, keep approval, state management, and reliable execution in application code.

## Course overview

The [curriculum](Curriculum.md) defines six modules. Materials for modules 1, 2, and 6 are currently included; modules 3–5 are planned.

| Module | Focus | Materials |
| --- | --- | --- |
| 1. AI Basics for Developers | LLM fundamentals, limitations, context, RAG, tool calling, and agents | [Slides, worksheet, and trainer guides](1-ai-basics/README.md) |
| 2. AI-Assisted Coding: Staying in Control | A coding dojo comparing one-shot generation, incremental development, and project context | [Draft slides, worksheet, and trainer guide](2-ai-assisted-coding/README.md) |
| 3. Tests as an AI Harness | Tests and automated checks as feedback for AI-assisted development | Planned |
| 4. Refactoring with AI | Understanding and improving existing code while preserving behavior | Planned |
| 5. Spec-Driven Development with AI | Turning requirements into specifications, implementation steps, and acceptance criteria | Planned |
| 6. Building Your First AI Agent | A C# travel assistant with tools, human approval, booking state, and failure recovery | [Starter project and exercises](6-coding-an-agent/README.md) |

Modules 1 and 2 are designed as two-hour workshops. Their teaching materials are primarily in German, with English module titles. Module 6 uses English instructions and C# code.

## Getting started

**For participants:** Start with the relevant module README. Modules 1 and 2 include presentation PDFs and worksheets; module 6 includes a starter application with exercises to complete.

**For trainers:** Review the [curriculum](Curriculum.md), then use each module's `Trainer/` directory for facilitation notes and solutions. Module READMEs describe preparation and workshop timing.

### Run the agent starter project

You need the .NET 10 SDK and a Mistral API key. From the repository root:

```powershell
cd 6-coding-an-agent/AIAgentTraining
dotnet restore
Copy-Item .env.example .env
```

Set your key in the new `.env` file:

```dotenv
MISTRAL_API_KEY=your-api-key
```

Then start the console application:

```powershell
dotnet run
```

Enter a travel request, or type `exit` to quit. Follow the [module 6 exercises](6-coding-an-agent/README.md) to add flight and hotel search, booking requests, polling, and recovery behavior.

The starter uses Microsoft Agent Framework, `Microsoft.Extensions.AI`, and Mistral's OpenAI-compatible API. Travel searches and bookings use a fake API with deterministic scenarios; model calls use the external Mistral service. Keep your API key local—the repository ignores `.env` files.

## Presentations

Modules 1 and 2 include editable Marp Markdown, HTML presentations, and PDF exports. You can read the PDFs directly or edit the slide sources with Marp for VS Code.

Each module README includes export commands. When sharing Markdown or HTML presentations, include the corresponding `assets/` directory. PDF exports are self-contained.

## Repository layout

```text
Curriculum.md              Six-module course outline
1-ai-basics/               Slides, worksheet, assets, and trainer materials
2-ai-assisted-coding/      Coding dojo slides, worksheet, and trainer materials
6-coding-an-agent/         Agent exercises and trainer materials
  AIAgentTraining/         .NET 10 console starter project
```

## Contributing

Corrections, clearer explanations, and exercise improvements are welcome. Include the module and file in your issue or pull request, and explain the proposed change. For slide changes, keep the editable Markdown and any updated exports consistent.
