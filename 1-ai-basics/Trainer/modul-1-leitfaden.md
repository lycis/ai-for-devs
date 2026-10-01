# Modul 1: Trainerleitfaden

Stand: 17.09.2026. Dieser Ablauf ist maßgeblich für die überarbeitete Präsentation. Die älteren Key Fact Cards und die Sicherung vor der Review dokumentieren den vorherigen Stand.

## Vorbereitung

- Präsentation und lokale Bilder gemeinsam bereithalten.
- [Arbeitsblatt](../arbeitsblatt-modul-1.md) vorab verteilen; Prompts müssen kopierbar sein.
- Freigegebener Modellzugang pro Pair, synthetische Daten, Timer und Sammelfläche.
- Kein Projektsetup nötig. Die Bestellübung ist ein Review, kein Live-Testlauf.
- Ohne Modellzugang in beiden Runden Regeln und Pseudocode entwerfen lassen.

## Ablauf: exakt 120 Minuten

| Zeit | Abschnitt | Aufteilung |
| --- | --- | --- |
| 00–10 | Einstieg | 3 Einstieg, 3 Pair, 4 Sammlung |
| 10–32 | Funktionsweise | 12 Impuls, 1 Auftrag, 6 Übung, 3 Auswertung |
| 32–48 | Fehleranalyse | 2 Material, 6 Pair, 5 Auswertung mit Larch, 3 Begriff/Belege |
| 48–60 | Kontext/Sicherheit | 0,5 Auftakt, 2 Quellen, 2 Kontextaufbau, 2 Kontextfenster, 1,5 Relevanz, 1 Daten, 3 Injection |
| 60–70 | Pause | 10 |
| 70–88 | Kontextvergleich | 1 Auftrag, 3 Runde 1, 5 Runde 2, 6 Review, 3 Auswertung |
| 88–108 | RAG/Tools/Agenten | 1 Einstieg, 2 RAG, 2 Tools, 2 Agent, 1 Grenzen, 8 Gruppe, 4 Debrief |
| 108–120 | Abschluss | 3 Check, 1 Kernbotschaften, 5 Transfer, 2 Fragen, 1 Ausblick |

Bei Verzögerung zusätzliche Wortmeldungen kürzen. Übungszeit und Pause schützen. Grundlagentheorie: Einordnung 0,5, Assistant 2, Training 1, Nachtraining/Reasoning 2, Tokens 1, Text 0,75, Code 0,75, Sampling 1 Minute. Verbleibende 3 Minuten für Übergänge und kurze Verständnisfragen.

## Fallanalyse: Lösungshinweise

Vor der Pair-Arbeit keine Annahmen markieren. Gegeben sind Library-Name und Aufgabe. Importpfad, OrderManager, Konstruktor, Methodennamen, synchrone Ausführung und Dictionary-Verträge mit success-Schlüssel sind im Kontext nicht belegt.

Diese Methoden könnten real existieren; das Material liefert keinen Nachweis. Als hypothetischer Entwurf kann der Code nützlich sein. Eine Integration ist damit nicht nachgewiesen.

Rückfrage: „Bitte zeige Importpfad, Typen, Signaturen, Rückgabeverträge und ein funktionierendes Nutzungsbeispiel.“ Anschließend Dokumentation/Paketstand prüfen, Integration bauen und gegen Stubs beziehungsweise Testumgebung testen. Keine echten Bestellungen versenden.

Larch: Angebotsanfrage belegt weder Projektverantwortung noch Verzögerungsursache oder Starttermin. Quellentreues Update: „Maya wird ein überarbeitetes Lieferantenangebot anfragen. Sobald es vorliegt, bespricht das Team den Startzeitplan erneut. Ursache, Projektverantwortung und neuer Termin gehen aus den Notizen nicht hervor.“

## Kontext und Sicherheit

Parameter, aktuellen Kontext und extern gespeicherte Informationen unterscheiden. Nachgeladene Dateien und Notizen müssen für den jeweiligen Aufruf in den Kontext gelangen. Große Kontextfenster garantieren keine zuverlässige Nutzung jedes Details.

Das Injection-Bild zeigt eine gewünschte Kontrollentscheidung, keine universelle Abwehr. Quelleninhalt autorisiert keine Aktion. Technische Rechte und Freigaben prüft die Anwendung. Das Beispiel ausschließlich analysieren.

## Kontextvergleich

Identischer technischer Rahmen in beiden Runden. Nur Runde 2 enthält Fachregeln und Beispiele. Neue Chats reduzieren den Einfluss der ersten Antwort; Produkt-Memory und automatische Quellen können trotzdem wirken.

Eine Rückfrage in Runde 1 ist ein Erfolg. Weder Halluzination noch Verbesserung in jedem Lauf werden vorausgesetzt. Zufall, Modellfähigkeit und Umgebung bleiben Einflussgrößen.

Die Matrix ist eine Review-Hilfe, kein Testergebnis. „Durchgesehen“, „verletzt“ oder „unklar“ statt „Tests bestanden“ verwenden. Bei ungültigen Orders ist RequiresApproval false. Exakt 10000 EUR benötigt keine Freigabe, 10000,01 EUR schon. Whitespace und decimal-Überlauf sind ausdrücklich geregelt. Fehlercodes und Reihenfolge bleiben offen.

## Architekturübung

Codebasis: Suche/Lesetools liefern Dateien, Modell erklärt und bildet Hypothesen, Builds/Tests prüfen Verhalten. Dateiverweise und Versionsstand kontrollieren. Ein Treffer beweist keine vollständige Analyse.

Deployment: Modell unterstützt Planung, Pipeline führt aus. Ziel, Revision, Checks, Rechte, Freigaben nach tatsächlichem Prozess und Rücksetzplan prüfen. Mensch verantwortet Ausnahmen. Bei fehlenden Belegen nachfragen oder stoppen.

### Reservefälle: ersetzen, nicht zusätzlich aufgeben

| Fall | Aufteilung | Grenze |
| --- | --- | --- |
| Resturlaub | Tool liest Fachsystem, Code rechnet, LLM formuliert | Identität, Berechtigung, Stichtag |
| Rechnungssumme | Code rechnet, LLM strukturiert optional Eingabe | Werte, Rundung und Ergebnis prüfen |
| Supportticket | LLM schlägt Kategorie vor | Erlaubte Kategorien, Evaluation und Stichproben |
| Anforderungen in 300 Dokumenten | Retrieval liefert Quellen, LLM extrahiert | Version und Suchabdeckung; vollständige Verarbeitung kann nötig sein |

## Wissenscheck

1. Datei: Inhalt kann Kontext verändern. Normale Inference ändert keine Parameter. Sichtbarkeit garantiert keine vollständige Verarbeitung.
2. Identische Antworten: beobachtete Wiederholbarkeit, kein Richtigkeitsnachweis.
3. RAG: Existenz, Version, Relevanz und Stützung prüfen. Abdeckung ist eine eigene Frage.
4. README/JSON: keine automatische Freigabe. Auftrag, Herkunft, Semantik, Rechte und gegebenenfalls menschliche Zustimmung prüfen.

## Anschlussmodule

Modul 2 operationalisiert Kontext, kleine Änderungen und Review. Modul 3 vertieft ausführbare Erwartungen und Feedback. Modul 4 behandelt Verhaltenserhalt. Modul 5 skaliert Spezifikationen. Modul 6 implementiert Tools, Zustandsverwaltung und Agentenschleifen. Modul 1 bereitet Begriffe und Grenzen vor.
