# Modul 1: AI Basics for Developers

Die [Marp-Präsentation](module-1-ai-basics.marp.md) umfasst **48 Folien und 120 Minuten einschließlich 10 Minuten Pause**.

- [HTML-Präsentation](module-1-ai-basics.html)
- [PDF-Präsentation](module-1-ai-basics.pdf)
- [Kopierbares Arbeitsblatt](arbeitsblatt-modul-1.md)
- [Aktueller Trainerleitfaden mit Lösungen](Trainer/modul-1-leitfaden.md)
- [Druckfertige Moderationsnotizen als PDF](../output/pdf/modul-1-moderationsnotizen.pdf) mit Zeitankern, Notizen zu allen 48 Folien und Lösungshinweisen auf 12 A4-Seiten
- [Bearbeitbare Moderationsnotizen](Trainer/modul-1-moderationsnotizen.md)

## Ablauf

| Minuten | Abschnitt |
| --- | --- |
| 00–10 | Erfahrungen im Entwickleralltag |
| 10–32 | Modell, Coding Assistant und Generierung |
| 32–48 | Eigenständige Fehleranalyse und Verifikation |
| 48–60 | Kontext, Datenfreigabe und Prompt Injection |
| 60–70 | Pause |
| 70–88 | Kontextvergleich mit identischem C#-Rahmen |
| 88–108 | RAG, Tools, Agenten und zwei Entscheidungsszenarien |
| 108–120 | Wissenscheck, Transfer und Fragen |

## Vorbereitung

Freigegebener Modellzugang pro Pair, synthetische Daten, Timer und Sammelfläche. Arbeitsblatt vorab verteilen. Die Bestellübung ist ein Review ohne Projektsetup. Ohne Modellzugang Regeln und Pseudocode auf Papier bearbeiten. Die Library-Fallanalyse benötigt keinen Modellzugang.

Moderationsnotizen stehen als HTML-Kommentare in der Marp-Datei. Der aktuelle Trainerleitfaden ersetzt für die Durchführung die älteren Key Fact Cards. Grundlage bleibt das [Curriculum](../Curriculum.md).

## Präsentieren und exportieren

Markdown mit Marp for VS Code öffnen. Beim Weitergeben der Markdown- oder HTML-Version den Ordner `assets` mitkopieren. Das PDF ist eigenständig.

```powershell
npx --yes @marp-team/marp-cli 1-ai-basics/module-1-ai-basics.marp.md --html -o 1-ai-basics/module-1-ai-basics.html
npx --yes @marp-team/marp-cli 1-ai-basics/module-1-ai-basics.marp.md --html --pdf --allow-local-files -o 1-ai-basics/module-1-ai-basics.pdf
```

Das HTML-Flag erlaubt die hervorgehobene Bildunterschrift. PDF benötigt einen unterstützten Browser. Fehlende Pakete werden beim ersten Aufruf heruntergeladen.

## Bildmaterial

Neu sind [Coding Assistant](assets/coding-assistant.png), [Prompt Injection](assets/prompt-injection.png) und [Tool Calling bei Tests](assets/tool-calling-tests.png). Alle drei wurden mit dem integrierten Imagegen-Werkzeug erstellt. Prompts stehen in [revision-prompts.md](assets/revision-prompts.md), Fachquellen in den Moderationsnotizen. Bestehende Schaubilder bleiben an passenden Stellen erhalten.

Der Original-Screenshot zu Larch bleibt unverändert als Quellenmaterial erhalten. Der vorherige Stand ist in `Trainer/module-1-before-review-2026-09-17.md` gesichert; seine relativen Bildpfade beziehen sich auf den ursprünglichen Modulordner.
