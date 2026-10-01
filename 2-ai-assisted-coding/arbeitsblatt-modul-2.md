# Arbeitsblatt · Modul 2

Team: ____________________  Coding Agent: ____________________

## FairShare

Eine kleine Anwendung zum Aufteilen gemeinsamer Ausgaben unter Freunden. Nutzer können Personen hinzufügen, Ausgaben erfassen, Zahler und Beteiligte angeben, Salden sehen und ermitteln, wer wem Geld zum Ausgleich zahlen sollte.

Jede Runde beginnt in einem neuen leeren Ordner und einem neuen Chat. Vorherige Ergebnisse behalten, aber nicht kopieren. Rollen je Runde wechseln: Driver bedient den Agenten, Navigator beobachtet und prüft. In Dreiergruppen ergänzt eine Person die Beobachtungen.

## Runde 1 · 15 Minuten

Kopierbarer Startprompt:

```text
Baue eine kleine Anwendung namens FairShare zum Aufteilen von Ausgaben
in einer Gruppe von Freunden.

Nutzer sollen Personen hinzufügen, gemeinsame Ausgaben erfassen,
Zahler und Beteiligte angeben, aktuelle Salden sehen und ermitteln,
wer wem Geld zum Ausgleich zahlen sollte.

Baue eine benutzbare Version der Anwendung.
```

Agent arbeiten lassen. Echte Rückfragen beantworten, vorerst nicht gezielt nachsteuern.

Was war überraschend gut? ______________________________________

Welche Entscheidung hat der Agent selbst getroffen? __________________

Würdet ihr den Code als PR freigeben? Warum? _______________________

## Runde 2 · 20 Minuten

Zuerst etwa 3 Minuten für eigene Slices verwenden. Pro Schritt nur den aktuellen Slice beauftragen. Änderung und Diff ansehen, ausführen, dann akzeptieren oder nachsteuern.

Unsere ersten Slices:

1. __________________________________________________________
2. __________________________________________________________
3. __________________________________________________________

Beispiel für einen einzelnen Slice, keine vorgeschriebene Reihenfolge:

```text
Implementiere nur dieses Inkrement:
Alice hat 20 € für ein Essen bezahlt, das sie gleichmäßig mit Bob teilt.
Zeige, dass Bob Alice 10 € schuldet.
Implementiere noch keine weiteren FairShare-Funktionen.
```

Würden wir diese Änderung vor dem nächsten Slice akzeptieren? __________

Welche technische Entscheidung blieb beim Agenten? __________________

## Runde 3 · 20 Minuten

Etwa 5 Minuten: Projektentscheidungen treffen. Folgendes leeres Gerüst als `.github/copilot-instructions.md` im neuen Projektordner anlegen und selbst ausfüllen. Prüfen, ob der Agent die Datei als Kontext lädt. Bei einem anderen Tool dessen unterstützte Projektanweisungen nutzen und notieren.

```markdown
# FairShare Project Instructions

## Technology

## Architecture

## Coding Guidelines

## Scope and Agent Behaviour
```

Danach etwa 15 Minuten mit derselben Slice- und Review-Schleife wie in Runde 2 arbeiten.

Welche Entscheidungen haben wir vorher festgelegt? ___________________

Woran haben wir erkannt, dass der Agent die Regeln berücksichtigt? _______

Welche Regel hat geholfen oder gestört? _____________________________

## Unser Vergleich

Optional 1–5 vergeben: 1 = wenig, 5 = viel. Bei Ballast bedeutet ein hoher Wert viel unnötige Komplexität. Für jede Einschätzung einen Beleg nennen. Ergebnisse bleiben subjektiv.

| Dimension | One-shot | Slices | Kontext + Slices | Konkreter Beleg |
| --- | --- | --- | --- | --- |
| Fortschritt | | | | |
| Verständnis | | | | |
| Kontrolle | | | | |
| Ballast | | | | |

Wo war der Slice zu klein? ________________________________________

Wo waren die Regeln zu eng? ______________________________________

Wann würden wir im Alltag bewusst viel delegieren? ___________________

## Code Smell Safari · 5 Minuten

Ein Beispiel für Scope Creep, Code Bloat, vorzeitige Abstraktion, Duplikation oder spekulative Komplexität suchen. Das Signal muss am tatsächlichen Code begründet werden. Keine Pflicht, etwas zu finden oder jetzt zu refactoren.

Datei / Stelle: __________________________________________________

Beobachtung und warum sie fragwürdig ist: ___________________________

Was nehmen wir in unseren Alltag mit? ______________________________
