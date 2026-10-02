# Trainerleitfaden · Modul 1

## Ziel und Vorbereitung

Die Teilnehmenden erklären Funktionsweisen und Grenzen von LLMs, erkennen unbelegte Aussagen und verteilen Aufgaben bewusst zwischen Modell, Tools, Code und Mensch. Teams aus zwei Personen; für die Architekturübung sind kleine Gruppen möglich. Dieser Leitfaden ist maßgeblich für die aktuelle Präsentation.

- Präsentation und lokale Bilder gemeinsam bereithalten.
- [Arbeitsblatt](../arbeitsblatt-modul-1.md) vorab verteilen; Prompts müssen kopierbar sein.
- Freigegebener Modellzugang pro Pair, synthetische Daten, Timer und Sammelfläche.
- Kein Projektsetup nötig. Die Bestellübung ist ein Review, kein Live-Testlauf.
- Ohne Modellzugang in beiden Runden Regeln und Pseudocode entwerfen lassen.

## Ablauf und Moderation

| Zeit | Folien | Durchführung |
| --- | --- | --- |
| 00:00–00:10 | 1–5 | 3 Min Einstieg, 3 Min Pair-Austausch, 4 Min Sammlung. |
| 00:10–00:32 | 6–18 | 12 Min Impuls, 1 Min Auftrag, 6 Min „Be the LLM“, 3 Min Auswertung. |
| 00:32–00:48 | 19–25 | 2 Min Material, 6 Min Pair, 5 Min Auswertung mit Larch, 3 Min Begriff/Belege. |
| 00:48–01:00 | 26–32 | 0,5 Min Auftakt, 2 Min Quellen, 2 Min Kontextaufbau, 2 Min Kontextfenster, 1,5 Min Relevanz, 1 Min Daten, 3 Min Injection. |
| 01:00–01:10 | 33 | 10 Min Pause; Rückkehrzeit sichtbar nennen. |
| 01:10–01:28 | 34–37 | 1 Min Auftrag, 3 Min Runde 1, 5 Min Runde 2, 6 Min Review, 3 Min Auswertung. |
| 01:28–01:48 | 38–46 | 1 Min Einstieg, je 2 Min RAG, Tools und Agent, 1 Min Grenzen, 8 Min Gruppe, 4 Min Debrief. |
| 01:48–02:00 | 47–50 | 3 Min Check, 1 Min Kernbotschaften, 5 Min Transfer, 2 Min Fragen, 1 Min Ausblick. |

Bei Verzögerung zusätzliche Wortmeldungen kürzen. Übungszeit und Pause schützen. Grundlagentheorie: Einordnung 0,5, Assistant 2, Training 1, Nachtraining/Reasoning 2, Tokens 1, Text 0,75, Code 0,75, Sampling 1 Minute. Verbleibende 3 Minuten für Übergänge und kurze Verständnisfragen.

## Hinweise je Übung

### Einstieg und „Be the LLM“

Je eine hilfreiche und eine schwierige AI-Erfahrung sammeln, noch keine Wertung vorgeben. In „Be the LLM“ pro Fragment zwei plausible Fortsetzungen und fehlende Fachinformation verlangen. Paris kann Frankreich nahelegen, `IsValid` eine null-Prüfung und SQL einen Filter. Keine Variante als einzig richtige Lösung behandeln: Stadtbezug, Geschäftsregeln beziehungsweise Schema und Suchziel fehlen. Die Fragmente werden nicht ausgeführt.

### Fallanalyse: Lösungshinweise

Vor der Pair-Arbeit keine Annahmen markieren. Gegeben sind Library-Name und Aufgabe. Importpfad, OrderManager, Konstruktor, Methodennamen, synchrone Ausführung und Dictionary-Verträge mit success-Schlüssel sind im Kontext nicht belegt.

Diese Methoden könnten real existieren; das Material liefert keinen Nachweis. Als hypothetischer Entwurf kann der Code nützlich sein. Eine Integration ist damit nicht nachgewiesen.

Rückfrage: „Bitte zeige Importpfad, Typen, Signaturen, Rückgabeverträge und ein funktionierendes Nutzungsbeispiel.“ Anschließend Dokumentation/Paketstand prüfen, Integration bauen und gegen Stubs beziehungsweise Testumgebung testen. Keine echten Bestellungen versenden.

Larch: Angebotsanfrage belegt weder Projektverantwortung noch Verzögerungsursache oder Starttermin. Quellentreues Update: „Maya wird ein überarbeitetes Lieferantenangebot anfragen. Sobald es vorliegt, bespricht das Team den Startzeitplan erneut. Ursache, Projektverantwortung und neuer Termin gehen aus den Notizen nicht hervor.“

### Kontext und Sicherheit

Parameter, aktuellen Kontext und extern gespeicherte Informationen unterscheiden. Nachgeladene Dateien und Notizen müssen für den jeweiligen Aufruf in den Kontext gelangen. Große Kontextfenster garantieren keine zuverlässige Nutzung jedes Details.

Das Injection-Bild zeigt eine gewünschte Kontrollentscheidung, keine universelle Abwehr. Quelleninhalt autorisiert keine Aktion. Technische Rechte und Freigaben prüft die Anwendung. Das Beispiel ausschließlich analysieren.

### Kontextvergleich

Identischer technischer Rahmen in beiden Runden. Nur Runde 2 enthält Fachregeln und Beispiele. Neue Chats reduzieren den Einfluss der ersten Antwort; Produkt-Memory und automatische Quellen können trotzdem wirken.

Eine Rückfrage in Runde 1 ist ein Erfolg. Weder Halluzination noch Verbesserung in jedem Lauf werden vorausgesetzt. Zufall, Modellfähigkeit und Umgebung bleiben Einflussgrößen.

Die Matrix ist eine Review-Hilfe, kein Testergebnis. „Durchgesehen“, „verletzt“ oder „unklar“ statt „Tests bestanden“ verwenden. Bei ungültigen Orders ist RequiresApproval false. Exakt 10000 EUR benötigt keine Freigabe, 10000,01 EUR schon. Whitespace und decimal-Überlauf sind ausdrücklich geregelt. Fehlercodes und Reihenfolge bleiben offen.

### Architekturübung

Codebasis: Suche/Lesetools liefern Dateien, Modell erklärt und bildet Hypothesen, Builds/Tests prüfen Verhalten. Dateiverweise und Versionsstand kontrollieren. Ein Treffer beweist keine vollständige Analyse.

Deployment: Modell unterstützt Planung, Pipeline führt aus. Ziel, Revision, Checks, Rechte, Freigaben nach tatsächlichem Prozess und Rücksetzplan prüfen. Mensch verantwortet Ausnahmen. Bei fehlenden Belegen nachfragen oder stoppen.

### Reservefälle: ersetzen, nicht zusätzlich aufgeben

| Fall | Aufteilung | Grenze |
| --- | --- | --- |
| Resturlaub | Tool liest Fachsystem, Code rechnet, LLM formuliert | Identität, Berechtigung, Stichtag |
| Rechnungssumme | Code rechnet, LLM strukturiert optional Eingabe | Werte, Rundung und Ergebnis prüfen |
| Supportticket | LLM schlägt Kategorie vor | Erlaubte Kategorien, Evaluation und Stichproben |
| Anforderungen in 300 Dokumenten | Retrieval liefert Quellen, LLM extrahiert | Version und Suchabdeckung; vollständige Verarbeitung kann nötig sein |

## Reflexion ohne vorgegebene Antwort

Beobachtungen mit einer konkreten Text- oder Codestelle begründen lassen. Fehlende Information, plausible Annahme und nachgewiesenes Verhalten unterscheiden. Eine hilfreiche Rückfrage ist ein Ergebnis. Im Kontextvergleich keine zwingende Verbesserung voraussetzen. Beim Architekturvergleich zählt die Begründung der Zuständigkeit.

## Wissenscheck

1. Datei: Inhalt kann Kontext verändern. Normale Inference ändert keine Parameter. Sichtbarkeit garantiert keine vollständige Verarbeitung.
2. Identische Antworten: beobachtete Wiederholbarkeit, kein Richtigkeitsnachweis.
3. RAG: Existenz, Version, Relevanz und Stützung prüfen. Abdeckung ist eine eigene Frage.
4. README/JSON: keine automatische Freigabe. Auftrag, Herkunft, Semantik, Rechte und gegebenenfalls menschliche Zustimmung prüfen.

## Anschlussmodule

Modul 2 operationalisiert Kontext, kleine Änderungen und Review. Modul 3 vertieft ausführbare Erwartungen und Feedback. Modul 4 behandelt Verhaltenserhalt. Modul 5 skaliert Spezifikationen. Modul 6 implementiert Tools, Zustandsverwaltung und Agentenschleifen. Modul 1 bereitet Begriffe und Grenzen vor.

## Fachreferenzen und Material

- [MARP-Quelle mit Fachquellen und Moderationsnotizen](../module-1-ai-basics.marp.md).
- [Arbeitsblatt mit kopierbaren Aufgaben](../arbeitsblatt-modul-1.md).
- [Curriculum](../../Curriculum.md): Lernziele und Anschlussmodule.
