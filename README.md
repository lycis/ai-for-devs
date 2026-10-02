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
| 6. Building Your First AI Agent | A C# travel assistant with tools, human approval, booking state, and failure recovery | [Starter project, worksheet, and trainer guide](6-coding-an-agent/README.md) |

Modules 1, 2, and 6 are designed as two-hour workshops. Their READMEs, trainer guides, and participant worksheets are in German, with English module titles and API identifiers. Module 1 includes a ten-minute break; modules 2 and 6 require a timing adjustment if a separate break is needed.

## Getting started

**For participants:** Start with the relevant module README for preparation and timing, then use its worksheet during the workshop. Modules 1 and 2 include editable slide sources; module 6 uses a starter application.

**For trainers:** Review the [curriculum](Curriculum.md), then follow the current trainer guide linked below. It provides preparation, a timed agenda, exercise guidance, and reflection questions. Older notes and outlines remain supplementary material.

| Module | Participant worksheet | Current trainer guide | Preparation |
| --- | --- | --- | --- |
| 1. AI Basics | [Tasks and context comparison](1-ai-basics/arbeitsblatt-modul-1.md) | [Facilitation and solution guidance](1-ai-basics/Trainer/modul-1-leitfaden.md) | Approved model access per pair; paper alternatives are available. No project setup required. |
| 2. AI-Assisted Coding | [FairShare prompts and observation sheet](2-ai-assisted-coding/arbeitsblatt-modul-2.md) | [Coding dojo facilitation](2-ai-assisted-coding/Trainer/modul-2-leitfaden.md) | Coding agent and local development environment. Teams choose their stack and start each round in a new empty folder and chat. |
| 6. Building Your First AI Agent | [Travel agent tasks and observation sheet](6-coding-an-agent/arbeitsblatt-modul-6.md) | [Agent workshop facilitation](6-coding-an-agent/Trainer/modul-6-leitfaden.md) | C# experience, .NET 10 SDK, and approved Mistral access. Exercises build on the supplied starter project. |

Use synthetic data and approved model or agent access throughout. Keep API keys local. Module-specific setup and commands live in the corresponding README, including [how to run the module 6 starter](6-coding-an-agent/README.md#vorbereiten-und-starten). Its travel API is fictitious; model calls use the configured external provider.

## Presentations

Modules 1 and 2 include editable Marp Markdown and the image assets needed to render the slides. Open the sources with Marp for VS Code, or generate HTML presentations and PDF exports locally. Generated exports are ignored by Git.

The READMEs for modules 1 and 2 include export commands. When sharing Markdown or HTML presentations, include the corresponding `assets/` directory. PDF exports are self-contained.

Module 6 currently has no Marp presentation; trainers use the starter project and trainer guide.

Worksheets and trainer notes are maintained as Markdown and can be printed or exported to PDF from a Markdown editor. The repository keeps sources and required assets; generated documents, build output, backups, and local credentials stay outside version control.

## Repository layout

```text
Curriculum.md              Six-module course outline
1-ai-basics/               Slides, worksheet, assets, and trainer materials
2-ai-assisted-coding/      Coding dojo slides, worksheet, and trainer materials
6-coding-an-agent/         Worksheet, trainer guide, and solution guidance
  AIAgentTraining/         .NET 10 console starter project
```

## Contributing

Corrections, clearer explanations, and exercise improvements are welcome. Include the module and file in your issue or pull request, and explain the proposed change. Keep each module's README, trainer guide, worksheet, and slides or starter project consistent. For slide changes, verify locally generated exports and commit the editable sources and required assets.

## License

Educational materials are licensed under [CC BY-SA 4.0](LICENSE-CC-BY-SA-4.0). Source code and code examples are licensed under [MIT](LICENSE-MIT).

See [Licensing](LICENSE.md) for the scope, attribution guidance, and third-party exceptions. Contributions are provided under the applicable license for the material contributed.
