# Modul 2: AI-Assisted Coding, Staying in Control

Erster Review-Entwurf: **18 Folien, 120 Minuten**, Coding-Dojo in Zweier- oder Dreiergruppen. Sprache und Gestaltung folgen Modul 1. Inhaltliche Grundlage ist die bereitgestellte Modul-2-Outline vom 01.10.2026.

- [MARP-Quelle mit Moderationsnotizen](module-2-ai-assisted-coding.marp.md)
- [Kopierbare Aufgaben und Beobachtungsbogen](arbeitsblatt-modul-2.md)
- [Trainerleitfaden](Trainer/modul-2-leitfaden.md)
- [Bildprompts und Herkunft](assets/image-prompts.md)

## Ablauf

| Zeit | Phase | Folien |
| --- | --- | --- |
| 00:00–00:10 | Setup, FairShare, Beobachtung | 1–4 |
| 00:10–00:25 | Runde 1: One-shot | 5 |
| 00:25–00:35 | Reflexion 1 | 6 |
| 00:35–00:45 | Elephant Carpaccio | 7–9 |
| 00:45–01:05 | Runde 2: Slices | 10 |
| 01:05–01:15 | Reflexion 2 | 11–12 |
| 01:15–01:25 | Projektkontext | 13–14 |
| 01:25–01:45 | Runde 3: Kontext + Slices | 15 |
| 01:45–01:57 | Vergleich und Code Smell Safari | 16–17 |
| 01:57–02:00 | Abschluss und Brücke zu Modul 3 | 18 |

## Präsentieren und exportieren

MARP-Quelle mit Marp for VS Code öffnen. HTML und PDF werden lokal aus der Marp-Quelle erzeugt und nicht in Git gespeichert. Markdown und HTML benötigen den mitgelieferten `assets`-Ordner. Das PDF ist eigenständig. Das Arbeitsblatt kann über einen Markdown-Editor gedruckt oder als PDF exportiert werden.

```powershell
npx --yes @marp-team/marp-cli 2-ai-assisted-coding/module-2-ai-assisted-coding.marp.md --html -o 2-ai-assisted-coding/module-2-ai-assisted-coding.html
npx --yes @marp-team/marp-cli 2-ai-assisted-coding/module-2-ai-assisted-coding.marp.md --html --pdf --allow-local-files -o 2-ai-assisted-coding/module-2-ai-assisted-coding.pdf
```

## Entscheidungen für das Review

- Deutsch wie Modul 1, englische Modulnamen bleiben erhalten.
- Die Zeiten der Outline bleiben erhalten. Runde 2 enthält etwa 3 Minuten Slice-Planung, Runde 3 etwa 5 Minuten Kontextarbeit. Die tatsächliche Coding-Zeit ist damit ungefähr vergleichbar.
- Jeder Neustart umfasst einen leeren Ordner und einen frischen Chat. Vorherige Ergebnisse bleiben für den Vergleich erhalten.
- Die Teams bestimmen Stack, Slices und Regeln selbst. Es gibt weder Starterprojekt noch fertige Slice-Reihenfolge.
- Menschliches Review, Ausführen und Compilerfeedback stehen im Mittelpunkt. TDD folgt in Modul 3.
- Die 120 Minuten enthalten keine separate Pause. Für eine Pause muss der Ablauf bewusst angepasst werden.

Die Illustration zur Kontextarbeit erklärt das Prinzip. Ob Anweisungsdateien tatsächlich geladen werden, muss im eingesetzten Tool geprüft werden. Technische Referenz: [VS Code Custom Instructions](https://code.visualstudio.com/docs/agent-customization/custom-instructions).
