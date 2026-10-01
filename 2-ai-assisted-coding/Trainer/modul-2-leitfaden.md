# Trainerleitfaden · Modul 2

## Ziel und Vorbereitung

Die Teilnehmenden gestalten die Zusammenarbeit mit einem Coding Agent so, dass sie Entscheidungen bewusst treffen und Änderungen reviewen können. FairShare dient als gemeinsamer Versuch, nicht als Lieferziel. Teams aus zwei oder drei Personen. Copilot Agent Mode bevorzugt, vergleichbare Tools möglich.

Vorab Agentzugang, Toolfreigaben und lokale Entwicklungsumgebung prüfen. Keine Stackentscheidung und kein Starterprojekt verteilen. Timer, Arbeitsblatt und gemeinsame Sammelfläche bereitstellen. Teams nutzen fiktive Namen und Ausgaben. Driver und Navigator wechseln pro Runde, dritte Person beobachtet bei Bedarf. Drei getrennte Projektordner und Chats verwenden. Frühere Ergebnisse aufbewahren.

## Ablauf und Moderation

| Zeit | Folien | Durchführung |
| --- | --- | --- |
| 00:00–00:10 | 1–4 | Leitfrage, Dojo, Produktidee und vier Beobachtungsdimensionen erklären. |
| 00:10–00:25 | 5 | One-shot-Prompt ausführen. Agententscheidungen beobachten, Teams nicht methodisch lenken. |
| 00:25–00:35 | 6 | 2 Min Teamreflexion, 6 Min Sammlung, 2 Min Einordnung. Mit Erfolgen beginnen. |
| 00:35–00:45 | 7–9 | Vertikale Slices über Elephant Carpaccio und das Alice/Bob-Verhalten erklären. |
| 00:45–01:05 | 10 | Etwa 3 Min Sliceplanung, 15 Min Umsetzung und Review, 2 Min Beobachtungen sichern. |
| 01:05–01:15 | 11–12 | 3 Min Teams, 5 Min Austausch, 2 Min Übergang vom Was zum Wie. |
| 01:15–01:25 | 13–14 | Offene technische Entscheidungen sammeln. Persistente Projektanweisungen einführen. |
| 01:25–01:45 | 15 | 5 Min Kontext schreiben, 15 Min Slices implementieren und prüfen. |
| 01:45–01:52 | 16 | 2 Min teamintern vergleichen, 5 Min Ergebnisse und Grenzen diskutieren. |
| 01:52–01:57 | 17 | 3 Min Safari, 2 Min konkrete Funde teilen. |
| 01:57–02:00 | 18 | Drei Prinzipien und ein Transfergedanke, Brücke zu Tests als AI Harness. |

Die Outline sieht 15/20/20 Minuten für die Runden vor. Durch Planungs- und Kontextzeit ergeben sich ungefähr gleiche Umsetzungszeiten. Dies ist ein Erfahrungsvergleich, kein kontrolliertes Experiment: Wiederholung, gewählte Technologien und Agentverhalten beeinflussen die Ergebnisse. Keine zwingende Rangfolge voraussetzen. Eine separate Pause ist nicht eingeplant.

## Hinweise je Runde

**Runde 1:** Stack, Datenmodell, Dateistruktur, Persistenz, Dependencies, UI und Abstraktionen beobachten. Teams dürfen echte Rückfragen beantworten. Unverständliche Befehle und Toolfreigaben bleiben menschliche Entscheidungen. Bei Setup-Problemen Zeitverlust als Beobachtung aufnehmen. Keine fertige App fordern.

**Runde 2:** Keine Musterreihenfolge vorgeben. Ein Slice zeigt vorführbares Verhalten und enthält nur die dafür nötige Technik. Beispielrechnung: Alice bezahlt 20 €, zwei Personen tragen jeweils 10 €, Bob schuldet Alice 10 €. Nach jeder Änderung Diff ansehen, Anwendung ausführen und entscheiden. TDD nicht einführen. Tests sind erlaubt, aber hier keine methodische Voraussetzung.

**Runde 3:** Die Teams füllen das leere Gerüst selbst. Beispiele für mögliche Entscheidungen nur bei Bedarf nennen, etwa Daten im Speicher oder ein bewusst gewähltes Framework. Anweisungsdatei relativ zum Projektroot anlegen. Im verwendeten Tool prüfen, ob sie geladen wird. Wenn die automatische Einbindung unklar ist, explizit als Kontext hinzufügen und die Abweichung dokumentieren. Anweisungen beeinflussen das Modell, erzwingen aber kein korrektes Verhalten. Review bleibt notwendig.

## Reflexion ohne vorgegebene Antwort

Fragen zu sichtbarem Fortschritt, Verständnis, Kontrolle und Ballast mit Code oder Beobachtungen belegen. Erst während der Reflexion optional subjektive Bewertungen vergeben. Wenn One-shot gut abschneidet, nach den Bedingungen fragen. Wenn Slicing stört, nach zu kleinen Schritten oder unnötigen Freigaben suchen. Wenn Kontext stört, nach Widersprüchen oder zu engen Regeln fragen.

Ein Wegwerfprototyp oder kleines Skript kann mehr Delegation vertragen. Bei kritischem Verhalten, unklaren Erwartungen oder Änderungen, die niemand mehr versteht, muss das Team den Rahmen enger setzen, selbst entscheiden oder Generierung pausieren. Dies ist eine Gesprächsanregung und kein zusätzlicher Theorieblock.

## Safari

Konkrete Datei und Stelle nennen. „Viele Interfaces“ allein beweist keine vorzeitige Abstraktion. Das Team erklärt, warum der aktuelle Bedarf die Struktur nicht rechtfertigt. Kein Refactoring starten. Wenn kein Smell sichtbar ist, eine nachvollziehbare Designentscheidung zeigen.

## Fachreferenzen

- [Elephant Carpaccio exercise, Henrik Kniberg, Übung nach Alistair Cockburn](https://uploads-ssl.webflow.com/5e3bed81529ab12a517031ab/5ece238ef1473a6416860f46_Elephant_Carpaccio_exercise.pdf): dünne vertikale Slices. Hier als FairShare-Variante adaptiert.
- [VS Code: Custom instructions](https://code.visualstudio.com/docs/agent-customization/custom-instructions): Projektanweisungen und Einbindung im Coding Agent, geprüft 01.10.2026. Andere IDEs und Agenten können abweichen.

Die ursprüngliche Outline liegt zur Nachvollziehbarkeit unter [module-2-outline.md](module-2-outline.md).
