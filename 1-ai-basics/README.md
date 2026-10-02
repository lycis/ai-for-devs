# Modul 1: AI Basics for Developers

**50 Folien, 120 Minuten einschließlich 10 Minuten Pause**, Grundlagenimpulse, Pair-Arbeit und gemeinsame Reflexion. Leitfrage: Was muss ich als Entwickler über moderne KI wirklich verstehen?

- [MARP-Quelle mit Moderationsnotizen](module-1-ai-basics.marp.md)
- [Kopierbare Aufgaben und Beobachtungsbogen](arbeitsblatt-modul-1.md)
- [Trainerleitfaden](Trainer/modul-1-leitfaden.md)
- [Bildprompts und Herkunft](assets/image-prompts.md), [ergänzende Bildprompts](assets/revision-prompts.md)

## Ablauf

| Zeit | Phase | Folien |
| --- | --- | --- |
| 00:00–00:10 | Erfahrungen im Entwickleralltag | 1–5 |
| 00:10–00:32 | Modell, Coding Assistant und Generierung | 6–18 |
| 00:32–00:48 | Fehleranalyse und Verifikation | 19–25 |
| 00:48–01:00 | Kontext, Datenfreigabe und Prompt Injection | 26–32 |
| 01:00–01:10 | Pause | 33 |
| 01:10–01:28 | Kontextvergleich mit identischem C#-Rahmen | 34–37 |
| 01:28–01:48 | RAG, Tools, Agenten und Entscheidungsszenarien | 38–46 |
| 01:48–02:00 | Wissenscheck, Transfer und Fragen | 47–50 |

## Präsentieren und exportieren

MARP-Quelle mit Marp for VS Code öffnen. HTML und PDF werden lokal aus der Marp-Quelle erzeugt und nicht in Git gespeichert. Markdown und HTML benötigen den mitgelieferten `assets`-Ordner. Das PDF ist eigenständig. Das Arbeitsblatt kann über einen Markdown-Editor gedruckt oder als PDF exportiert werden.

```powershell
npx --yes @marp-team/marp-cli 1-ai-basics/module-1-ai-basics.marp.md --html -o 1-ai-basics/module-1-ai-basics.html
npx --yes @marp-team/marp-cli 1-ai-basics/module-1-ai-basics.marp.md --html --pdf --allow-local-files -o 1-ai-basics/module-1-ai-basics.pdf
```

## Entscheidungen für das Review

- Deutsch wie Modul 2, englische Modulnamen bleiben erhalten.
- Zeiten und Übungen bleiben erhalten. Die aktuelle Quelle enthält 50 Folien.
- Beide Kontextrunden verwenden denselben technischen Rahmen. Nur Runde 2 ergänzt Fachregeln und Beispiele. Antworten für den Vergleich behalten.
- Menschliches Review steht im Mittelpunkt. Die Review-Matrix dokumentiert keine ausgeführten Tests.
- Freigegebener Modellzugang pro Pair und synthetische Daten. Ohne Modellzugang Regeln und Pseudocode auf Papier bearbeiten; die Fallanalyse benötigt keinen Zugang.
- Der Trainerleitfaden ist maßgeblich. [Separate Moderationsnotizen](Trainer/modul-1-moderationsnotizen.md) und [Key Fact Cards](Trainer/module-1-ai-basics-key-fact-cards.md) bleiben ergänzendes Material aus einem früheren Stand.

Grundlage ist das [Curriculum](../Curriculum.md). Fachquellen stehen in den Moderationsnotizen der Präsentation; der [Original-Screenshot zu Larch](assets/hallucination-project-larch.png) bleibt als Quellenmaterial erhalten.
