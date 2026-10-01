---
marp: true
theme: default
paginate: true
size: 16:9
lang: de
title: AI Basics for Developers – Modul 1
description: Grundlagen, Grenzen und Einsatz von LLMs. Interaktives Training für Entwickler in 120 Minuten.
footer: 'AI Basics for Developers · Modul 1'
style: |
  section {
    background: #f8fafc;
    color: #172b4d;
    font-family: 'Segoe UI', Arial, sans-serif;
    font-size: 28px;
    line-height: 1.35;
    padding: 54px 68px;
    justify-content: center;
  }
  h1 { font-size: 44px; color: #102a43; letter-spacing: -1px; }
  h2 { font-size: 32px; color: #126b75; }
  strong { color: #126b75; }
  li { margin: 0.3em 0; }
  table { font-size: 23px; width: 100%; }
  th { background: #e3eef1; }
  pre { background: #eaf0f5; font-size: 23px; padding: 18px 22px; }
  code { font-family: Consolas, monospace; }
  blockquote { border-left: 5px solid #16828c; color: #24445a; padding-left: 22px; }
  footer, section::after { font-size: 16px; color: #627d98; }
  section.lead { background: #102a43; color: #f8fafc; }
  section.lead h1 { color: #ffffff; font-size: 60px; }
  section.lead h2, section.lead strong { color: #80ddd1; }
  section.lead footer, section.lead::after { color: #bdd3e2; }
  section.exercise { background: #edf8f5; }
  section.exercise h1 { color: #075b52; }
  section.compact { font-size: 25px; }

  section.probability .probability-note { position: absolute; bottom: 15px; left: 45px; right: 45px; text-align: center; background: #f8fafc; color: #102a43; font-size: 22px; font-weight: 600; }
---
<!-- _class: lead -->
<!-- _paginate: false -->

# AI Basics for Developers
## Modul 1

Wie funktionieren LLMs, wo liegen ihre Grenzen,
und wie setzen wir sie sinnvoll ein?

**120 Minuten mit Übungen und Pause**

<!--
Moderation: Willkommen heißen. Zielgruppe sind Entwickler mit grundlegender Programmiererfahrung. Keine ML-Vorkenntnisse erforderlich. Beispiele nutzen C# und SQL, die Konzepte sind sprachunabhängig.
Vorbereitung: Ein freigegebenes LLM pro Pair, Editor oder Papier, sichtbarer Timer und gemeinsame Sammelfläche. Nur synthetische Beispieldaten verwenden. Ohne Modellzugang funktionieren die Übungen als Papieraufgaben, bei der Halluzinationsübung den bereitgestellten Screenshot als festen Analysefall nutzen.
Inhaltsbasis: ../Curriculum.md. Überarbeitung vom 17.09.2026: 120 Minuten einschließlich 10 Minuten Pause. Verbindlicher Ablauf und Lösungen: Trainer/modul-1-leitfaden.md. Kopierbare Aufgaben: arbeitsblatt-modul-1.md.
-->

---
# Nach diesem Modul könnt ihr …

- Modell und Coding Assistant unterscheiden,
- erklären, wie LLMs Antworten erzeugen,
- Tokens und Context Window einordnen,
- Fehler erkennen und Ergebnisse prüfen,
- Prompting, Kontext, RAG, Tools und Agenten unterscheiden,
- Aufgaben zwischen Modell, Software und Menschen aufteilen.

<!-- Moderation: Lernziele kurz vorstellen. Am Ende prüfen wir diese Fähigkeiten an konkreten Szenarien. Keine tiefgehende Modellarchitektur und kein Training eines eigenen Modells. -->

---
# Unser Ablauf

| Zeit | Thema | Arbeitsform |
| :--- | :--- | :--- |
| 00–10 | AI im Entwickleralltag | Austausch |
| 10–32 | Modell und Coding Assistant | Impuls und „Be the LLM“ |
| 32–48 | Fehler erkennen und prüfen | Fallanalyse |
| 48–60 | Kontext und sichere Nutzung | Impuls und Kurzfrage |
| 60–70 | Pause | 10 Minuten |
| 70–88 | Gleiche Aufgabe, besserer Kontext | Vergleich und Review |
| 88–108 | RAG, Tools und Agenten | Beispiel und Gruppenarbeit |
| 108–120 | Transfer | Wissenscheck und 1–1–1 |

<!-- Alle Zeiten einschließlich Übergängen. Theorieimpulse maximal 12 Minuten. Block 1: Einstieg und Agenda 3, Pair-Austausch 3, Sammlung 4 Minuten. -->

---
<!-- _class: exercise -->

# AI in eurem Entwickleralltag
## Austausch zu zweit · 3 Minuten

1. Wo nutzt du AI bereits?
2. Was hat überraschend gut funktioniert?
3. Welches Ergebnis hat dich Zeit gekostet?
4. Was möchtest du heute besser verstehen?

**Danach:** Pro Pair ein Beispiel für „Hilft“ oder „Nervt“.

<!-- Timing Block 1: Einstieg inklusive Lernziele und Agenda 3 Min., Pair-Austausch 3 Min., Sammlung 4 Min. Summe 10 Min. Bei großen Gruppen nur vier Beiträge, übrige schriftlich sammeln. -->

---
# Unsere Erfahrungen als Ausgangspunkt

| Hilft | Nervt |
| :--- | :--- |
| Welche Arbeit ging leichter? | Was war falsch oder unbrauchbar? |
| Wie haben wir das geprüft? | Welche Information fehlte? |

**Arbeitsfrage für heute:**
Was erklärt diese Unterschiede und was können wir beeinflussen?

<!-- Moderation: Keine Antworten vorwegnehmen. Aussagen der Gruppe sammeln, etwa Testentwürfe oder erfundene APIs. Später auf diese konkreten Beispiele zurückkommen. Übergang: Viele Beobachtungen werden verständlicher, wenn wir die Generierung betrachten. -->

---
<!-- _class: lead -->

# Wie ein LLM arbeitet
## Plausible Fortsetzungen und ihre Grenzen

<!-- Block 2: 10–32. Folien bis zur Übung als 12-Minuten-Impuls mit Schaubildern gestalten. Übung und Auswertung zusammen 10 Minuten. -->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/ai_zusammenhänge.png)
<!-- Moderation: Einordnung bewusst vereinfacht. Nicht jede KI ist ein LLM. Generative AI umfasst weitere Modelltypen. Ein Chatprodukt kann zusätzlich Suche, Dateien und ausführbare Werkzeuge enthalten. -->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/coding-assistant.png)

<!--
Was steckt in einem Coding Assistant? 2 Minuten.
Das Modell erhält den von der Anwendung zusammengestellten Kontext. Es hat keinen automatischen Zugriff auf das gesamte Repository, das Internet oder eine Shell. Welche Werkzeuge verfügbar sind und ausgeführt werden dürfen, bestimmt die Anwendung. Antworten werden angezeigt, Aufrufvorschläge technisch geprüft und gegebenenfalls ausgeführt. Rückgaben können in den nächsten Modellaufruf gelangen. Noch keine Agentendetails erklären.
Quelle: https://www.anthropic.com/engineering/effective-context-engineering-for-ai-agents
Bild: Integriertes Imagegen. Prompt und Überarbeitung in assets/revision-prompts.md.
-->
---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/model.png)

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/training-inference.png)

<!--
Training und Inference
Moderation: 1 Minute. Oben verändern Trainingsdaten über einen Lernprozess die Parameter. Unten nutzt das trainierte Modell sie für eine Antwort auf den aktuellen Kontext. Normale Inference trainiert das Modell nicht neu. Diese technische Aussage ist keine Zusage über Speicherung oder spätere Datennutzung durch Anbieter. Übergang: Wie entstehen die Fähigkeiten zum Befolgen von Anweisungen und Lösen von Aufgaben?
Bild: Mit Imagegen erzeugtes Schema. Prompts in assets/schematic-prompts.md.
-->

---
# Training, Nachtraining und Reasoning

- **Vortraining:** Aus vielen Beispielen entstehen gelernte Muster
  für Sprache, Code und Zusammenhänge.
- **Nachtraining:** Beispiele und Feedback formen das Verhalten,
  etwa das Befolgen von Anweisungen und Lösen von Aufgaben.
- **Reasoning:** Manche Modelle nutzen zusätzliche Rechenschritte
  bei der Bearbeitung einer Anfrage.

Auch eine ausführliche Herleitung braucht **prüfbare Ergebnisse**.

<!-- 2 Minuten. Vereinfachte Phasen, keine vollständige Trainingspipeline. Schrittweise Token-Erzeugung beschreibt den Ausgabemechanismus, nicht die Obergrenze möglicher Fähigkeiten. Reasoning ist keine Wahrheitsgarantie. Angezeigte Denktexte sind keine verlässliche vollständige Darstellung interner Ursachen. Je nach Modell und Aufgabe fallen zusätzliche Zeit und Rechenkosten an.
Quellen: https://www-cdn.anthropic.com/de8ba9b01c9ab7cbabf5c33b80b7bbc618857627/Model_Card_Claude_3.pdf ; https://www.anthropic.com/research/reasoning-models-dont-say-think
-->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/tokens.png)

<!--
Tokens und Token-IDs
Moderation: 1 Minute. Die Zerlegung und IDs sind frei erfunden, keine Ausgabe eines realen Tokenizers. Das Leerzeichen vor prüfen ist in dieser vereinfachten Darstellung mitgemeint. Tokens können Wörter, Wortteile oder Zeichen sein; ihre IDs sind Vokabulareinträge, keine Bedeutungswerte. Übergang: Aus solchen Einheiten erzeugt das Modell nun die Fortsetzung.
Bild: Mit Imagegen erzeugtes Schema. Prompts in assets/schematic-prompts.md.
-->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/next-token-text.png)

<!-- _class: probability -->

<div class="probability-note">Illustrative Werte. Tokenwahrscheinlichkeit ist keine Wahrheitswahrscheinlichkeit.</div>

<!--
Eine plausible Fortsetzung: Sprache.
Moderation: Etwa 45 Sekunden erklären, keine zweite Vervollständigungsübung vorwegnehmen. Links steht der Kontext, rechts eine illustrative Verteilung. Greedy Decoding wählt hier blau mit 60 Prozent. Die Werte sind frei erfunden, keine Messwerte eines Modells. Andere fasst die übrigen Möglichkeiten zusammen.
Fachliche Vereinfachung: Wörter stehen stellvertretend für Tokens, die tatsächliche Tokenisierung kann anders aussehen. Das Netz berechnet aus dem Kontext über gelernte Parameter und Vektorrepräsentationen Ausgabewerte (Logits). Softmax wandelt sie in eine Wahrscheinlichkeitsverteilung um. Die Grafik überspringt diese internen Schritte. Die Wahrscheinlichkeit gilt für die Fortsetzung, nicht für die Wahrheit der Aussage über den Himmel. Greedy wählt das wahrscheinlichste nächste Token, nicht garantiert die wahrscheinlichste vollständige Antwort. Sampling kann eine andere Option wählen.
Bild: Mit dem integrierten Imagegen-Werkzeug erzeugte didaktische Illustration. Prompt dokumentiert in assets/image-prompts.md.
-->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/next-token-code.png)

<!--
Eine plausible Fortsetzung: Code.
Moderation: Etwa 45 Sekunden. Derselbe Mechanismus gilt für Code. Die illustrative Verteilung setzt return auf 55 Prozent, throw auf 30, logger auf 10 und andere Fortsetzungen zusammen auf 5 Prozent. Greedy wählt return. Das Beispiel endet bewusst vor Rückgabewert und Semikolon: Erst weitere Vorhersageschritte erzeugen den restlichen Code. Die Kandidaten stehen vereinfacht für nächste Tokens; Einrückung und konkrete Tokenisierung sind ausgeblendet.
Nach jedem gewählten Token verarbeitet das Modell die erweiterte Folge und berechnet die nächste Verteilung. Die höchste Fortsetzungswahrscheinlichkeit garantiert keine passende Fehlerbehandlung. Ob return oder throw fachlich sinnvoll ist, hängt von den Anforderungen und dem umgebenden Code ab. Hier nur erläutern. Eigene Fortsetzungen sammeln die Teilnehmer später in Be the LLM. Beide Bildfolien teilen sich das bestehende Zeitfenster des Theorieimpulses.
Bild: Mit dem integrierten Imagegen-Werkzeug erzeugte didaktische Illustration. Prompt dokumentiert in assets/image-prompts.md.
-->
---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg conain](assets/multidimension_llm_prediction.png)

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/greedy-sampling.png)

<!--
Greedy und Sampling
Moderation: 1 Minute. Die Verteilung entspricht dem Satzbeispiel. Links gewinnt immer das größte Gewicht bei identischer Verteilung; rechts sind drei unabhängige illustrative Ziehungen für denselben Kontext gezeigt, keine aufeinanderfolgenden Tokens einer Antwort. Die Zahlen sind erfunden. Sampling zieht gewichtet, nicht gleichverteilt. Kontext, Modell und Einstellungen können Ergebnisse zusätzlich verändern. Gleiche Ausgabe beweist keine Wahrheit. Übergang: Jetzt wählen die Teilnehmer selbst Fortsetzungen und suchen die fehlenden Anforderungen.
Bild: Mit Imagegen erzeugtes Schema. Prompts in assets/schematic-prompts.md.
-->

---
<!-- _class: exercise -->

# Be the LLM
## Pairs · 6 Minuten

```text
Paris ist die Hauptstadt von …
```

```csharp
public bool IsValid(Order order) {
```
```sql
SELECT * FROM users WHERE
```

Je Fragment: **zwei Fortsetzungen**, eine bevorzugte Variante
und die **fehlende Information** für eine fachliche Entscheidung.

<!-- Moderation: 1 Min. Auftrag, 6 Min. Pair-Arbeit, 3 Min. Auswertung auf nächster Folie. Papieraufgabe ohne Modellzugang. SQL nicht gegen echte Daten ausführen. -->

---
# Auswertung: Muster und Anforderungen

| Fragment | Plausible Fortsetzung | Was noch fehlt |
| :--- | :--- | :--- |
| Paris … | Frankreich | Ist diese Stadt gemeint? |
| IsValid … | Prüfung auf `null` | Geschäftsregeln und Fehlermodell |
| WHERE … | `active = 1` | Schema, SQL-Dialekt und Suchziel |

**Welche eurer Entscheidungen beruhte auf einer Annahme?**

<!-- Moderation: Beispielantworten, kein eindeutiger Lösungsschlüssel. Selbst bei Paris kann der Kontext eine andere gleichnamige Stadt meinen. Bei Code und SQL fehlen entscheidende Anforderungen. Überleitung zur nächsten Einheit: Das Modell kann fehlende Information mit plausiblen Details füllen. -->

---
<!-- _class: lead -->

# Fehler erkennen und prüfen
## Was wissen wir, was nehmen wir an?

<!-- Block 3: 32–48. Auftrag und Material 2, Pair-Analyse 6, Auswertung inklusive Larch 5, Begriff und Verifikation 3 Minuten. Vor der Übung keine Fehler markieren oder Lösungen nennen. Arbeitsblatt Abschnitt 1 verteilen. -->

---
# Eine interne Library verwenden

**Auftrag:** „Nutze unsere interne OrderManagementLibrary.
Schreibe eine Funktion, die eine Bestellung prüft und versendet.“

```python
from OrderManagementLibrary import OrderManager  # Hypothetical import

order_manager = OrderManager()
verification_result = order_manager.verify_order(order_data)
if not verification_result.get("success", False):
    ...
send_result = order_manager.send_order(order_data)
```

Die Antwort bezeichnet den Code als **hypothetischen Entwurf**.

<!-- 2 Minuten einschließlich Auftrag. Nutzerfall: Prompt sinngemäß ins Deutsche übersetzt, Codeauszug gekürzt. Warnung laut bereitgestelltem Fall vorhanden. Keine Schnittstellenbeschreibung verfügbar. Noch nicht erläutern, welche Teile unbelegt sind. Nicht ausführen. Vollständiges Untersuchungsmaterial in arbeitsblatt-modul-1.md. -->

---
<!-- _class: exercise -->

# Was könnt ihr daraus übernehmen?
## Analyse zu zweit · 6 Minuten

1. Markiert: **gegeben**, **angenommen**, **noch zu prüfen**.
2. Welche Informationen fehlen für eine echte Integration?
3. Formuliert die wichtigste Rückfrage.
4. Wählt passende Belege und Prüfungen vor einem Einsatz.

**Zusatzfrage:** Was ändert die Kennzeichnung „hypothetisch“?

<!-- 2 Minuten markieren, 2 Minuten Rückfrage und Prüfungen, 2 Minuten im Pair abgleichen. Papieraufgabe ohne Modellzugang. Material bleibt im Arbeitsblatt sichtbar. Lösungen erst danach zeigen. -->

---
# Auswertung: Entwurf und Integration

| Beobachtung | Konsequenz |
| :--- | :--- |
| Library-Name und Ziel sind gegeben | Aufgabe ist grob beschrieben |
| Klasse, Methoden und Rückgaben sind angenommen | Signaturen und Beispiele anfordern |
| Code ist als hypothetisch gekennzeichnet | Als Entwurf bewerten |
| Versand hätte eine Außenwirkung | Mit Stub in Testumgebung prüfen |

**Eine plausible Schnittstelle ist noch kein belegter API-Vertrag.**

<!-- 3 Minuten inklusive zweier Beiträge. Es ist nicht bewiesen, dass Methoden in der Realität nicht existieren. Belegt ist nur: Der vorliegende Kontext beschreibt sie nicht. Hypothetische Entwürfe können nützlich sein. Erwartete Rückfrage: Bitte zeige Importpfad, Methodensignaturen, Datenmodell und Rückgabeverträge. -->

---
# Kontrastfall: Ein Projektupdate

**Notizen:** Maya fragt ein überarbeitetes Angebot an.
Danach bespricht das Team den Startzeitplan erneut.

**Die Antwort ergänzt:** Maya sei projektverantwortlich,
die Spezifikationen seien überholt und der Start verschiebe
sich um zwei Wochen.

**Welche dieser Aussagen stützen die Notizen?**

<!-- 2 Minuten. Erst Zuruf, dann auflösen: keine der ergänzten Angaben. Anders als beim markierten Codeentwurf stellt die Antwort Ergänzungen als Projektstatus dar. Quelle: vorhandener Original-Screenshot assets/hallucination-project-larch.png; beide Texte hier sinngemäß gekürzt. Der ursprüngliche Auftrag unterstellt bereits eine Lieferantenverzögerung. Volltext und Hintergrund im Arbeitsblatt/Trainerhinweisen, Screenshot nicht neu generiert. -->

---
# Was wir hier Halluzination nennen

Eine Ausgabe stellt **erfundene, falsche oder durch die Quelle
nicht gedeckte Angaben** als Tatsachen dar.

- Fehlende Information führt nicht automatisch zu einer Rückfrage.
- Das Modell kann falsche Voraussetzungen der Frage übernehmen.
- Sprachliche Sicherheit belegt keine faktische Sicherheit.

Auch mit gutem Kontext können Fehler auftreten.

<!-- 1 Minute. Nicht jede unpassende Antwort oder jeder offen hypothetische Entwurf ist eine Halluzination. Fehler können außerdem durch missverstandene Anforderungen oder falsche Anwendung entstehen. -->

---
# Prüfung braucht unabhängige Belege

| Behauptung | Passende Prüfung |
| :--- | :--- |
| „Diese API existiert.“ | Offizielle Dokumentation und Paketversion |
| „Dieser Code funktioniert.“ | Build und passende Tests |
| „Das steht im Repository.“ | Datei und konkrete Fundstelle |
| „Das erfüllt die Fachregel.“ | Akzeptanzkriterien und fachliche Prüfung |

Eine Bestätigung durch dasselbe Modell liefert
**noch keinen unabhängigen Nachweis**.

<!-- 2 Minuten. Quellen öffnen und Aussagen abgleichen. Tests belegen überprüftes Verhalten, keine vollständige Fehlerfreiheit. Nicht nur die generierte Erklärung beurteilen. Überleitung: Fehlende Informationen gezielt bereitstellen. -->

---
<!-- _class: lead -->

# Prompting und Kontext
## Welche Informationen stehen wirklich zur Verfügung?

<!-- Block 4: 48–60. Auftakt 0,5, Informationsquellen 2, Kontextaufbau 2, Kontextfenster 2, Relevanz 1,5, Datenfreigabe 1, Prompt Injection mit Kurzfrage 3 Minuten. -->

---
# Woher kommt die Information?

| Quelle | Bedeutung für unsere Arbeit |
| :--- | :--- |
| Gelernte Parameter | Allgemeine Muster, kein aktueller Repository-Stand |
| Aktueller Kontext | Anweisungen und mitgegebene Informationen |
| Nachgeladene Quellen | Dateien, Dokumentation oder Tool-Ergebnisse |
| Gespeicherte Notizen | Von der Anwendung bei Bedarf wieder eingebracht |

**Eine Datei beeinflusst die Antwort, wenn ihr Inhalt
in den verarbeiteten Kontext gelangt.**

<!-- 2 Minuten. Kategorien beschreiben Herkunft, nicht vier getrennte Speicher im Modell. Nachgeladene Quellen und Notizen werden für den Modellaufruf Teil des Kontexts. Ein Chat trainiert das Modell nicht automatisch neu. Gespeicherte Notizen sind eine optionale Produktfunktion. Quelle: https://www.anthropic.com/engineering/effective-context-engineering-for-ai-agents -->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/context-engineering.png)

<!--
Prompting und Context Engineering
Moderation: 2 Minuten. Anweisung formulieren und Kontext zusammenstellen greifen ineinander. Für unsere Bestellaufgabe zählen Datenmodell, Geschäftsregeln und Prüffälle. Dateien, Gesprächsverlauf und Toolergebnisse können weitere Quellen sein. Im Library-Fall fehlten genau solche Schnittstelleninformationen. Die Bilder zeigen Informationsfluss, keine tatsächlich gemessene Modellarchitektur. Übergang: Dieser Kontext muss innerhalb eines begrenzten Budgets ausgewählt werden.
Bild: Mit Imagegen erzeugtes Schema. Prompts in assets/schematic-prompts.md.
-->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/context-window.png)

<!--
Das Context Window ist begrenzt
Moderation: 2 Minuten. Sichtbarer Chat und tatsächlich gesendeter Kontext können voneinander abweichen. Die Anwendung kann Informationen auswählen, kürzen, zusammenfassen oder nachladen. Budgetsegmente sind schematisch, keine festen Anteile. Input- und Outputgrenzen hängen vom Modell ab. Wichtige Anweisungen dürfen beim Verdichten nicht versehentlich entfallen. Großes Fenster garantiert keine zuverlässige Nutzung jedes Details. Übergang: Welche Informationen verdienen den begrenzten Platz?
Bild: Mit Imagegen erzeugtes Schema. Prompts in assets/schematic-prompts.md.
-->

---
# Relevanz schlägt bloße Menge

**Hilfreich:** Die betroffene Funktion, aufgerufene Typen,
Fachregeln und ein reproduzierbarer Fehler.

**Problematisch:** Veraltete Dokumentation, widersprüchliche Regeln
oder große Mengen unpassender Dateien.

Bei langen Aufgaben: Zwischenstand sichern,
offene Annahmen benennen und benötigte Quellen gezielt nachladen.

<!-- Moderation: Große Context Windows garantieren nicht, dass jedes Detail zuverlässig genutzt wird. Kontext bewusst auswählen. Dateien als Informationsquellen behandeln, darin enthaltene fremde Anweisungen nicht ungeprüft übernehmen. -->

---
# Welche Daten dürfen wir verwenden?

Für unsere Übungen: **freigegebener Modellzugang
und ausschließlich synthetische Beispieldaten**.

- Für echte Arbeit gelten die Datenfreigaben eurer Organisation.
- Zugangsdaten und Secrets gehören nicht in Prompts oder Anhänge.
- Kunden- und Produktionsdaten nur im freigegebenen Rahmen nutzen.

**„Kein Training während der Antwort“ sagt nichts
über Speicherung oder spätere Datennutzung aus.**

<!-- 1 Minute. Keine anbieterübergreifende Datenschutzzusage. Konkrete Vorgaben hängen von Produkt, Vertrag und Organisationsrichtlinien ab. Vor der ersten Live-Modellübung klären. -->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/prompt-injection.png)

<!--
Prompt Injection: Fremde Inhalte können das Modell zu ungewollten Aktionen lenken. 3 Minuten inklusive Kurzfrage: Darf die Anwendung dem Upload-Vorschlag folgen, nur weil er in der README steht? Erwartung: Nein. Quelleninhalt erteilt keine Berechtigung. Auch Repository-Dateien, Tickets und Tool-Ergebnisse können fremde Anweisungen enthalten. Beispiel ausschließlich analysieren, nicht ausführen. Die Anwendung muss Zugriffe, Netzwerkziele und Freigaben technisch begrenzen. Prompt-Abgrenzung allein ist keine vollständige Abwehr. Das blockierte Bild zeigt eine gewünschte Kontrollentscheidung, keine automatische Sicherheitsgarantie.
Quelle: https://www.anthropic.com/news/prompt-injection-defenses
Bild: Integriertes Imagegen, assets/revision-prompts.md.
-->

---
<!-- _class: lead -->

# Pause
## 10 Minuten

Weiter bei Minute 70.

<!-- Moderation: Konkrete Uhrzeit für die Rückkehr nennen oder sichtbar notieren. -->

---
<!-- _class: exercise -->

# Gleiche Aufgabe, besserer Kontext
## Vergleich zu zweit · 14 Minuten

**Runde 1 · 3 Minuten**
Basisprompt aus dem Arbeitsblatt senden. Annahmen markieren.

**Runde 2 · 5 Minuten**
Neuer Chat, gleiches Modell und gleicher Basisprompt.
Zusätzlich die Fachregeln aus dem Arbeitsblatt mitgeben.

**Review · 6 Minuten**
Beide Entwürfe anhand der Prüffälle lesen und vergleichen.

<!-- Block 5: 70–88. Auftrag mit technischem Rahmen 1, Übung 14, Auswertung 3 Minuten. Arbeitsblatt vorab öffnen. Es geht um Review, kein Testlauf erforderlich. Ohne Modellzugang Regeln und Pseudocode zunächst ohne, dann mit Fachregeln entwerfen. Modell und Einstellungen konstant halten. Der Vergleich ist eine Lernübung, kein Benchmark. -->

---
<!-- _class: exercise compact -->

# Gleicher Rahmen in beiden Runden

**C# · reine Funktion `Validate(Order? order)`**

```csharp
record Order(string? CustomerNumber,
             List<OrderItem?>? Items, decimal TotalAmount);
record OrderItem(int Quantity, decimal UnitPrice);
record ValidationError(string Code, string Field);
record ValidationResult(List<ValidationError> Errors,
                        bool IsValid, bool RequiresApproval);
```

Keine externen Aufrufe. Keine Freigabeaktion auslösen.
Fehler strukturiert zurückgeben. Offene Annahmen benennen.

**Runde 2 ergänzt Fachregeln und erwartetes Verhalten.**

<!-- 1 Minute gemeinsam mit vorheriger Folie. Vollständige kopierbare Prompts in arbeitsblatt-modul-1.md, Abschnitt 2. Die technischen Vorgaben bleiben identisch. RequiresApproval-Semantik und konkrete Ungültigkeitsregeln werden erst in Runde 2 bekannt. C#-Records mit Nullable Reference Types und System.Collections.Generic. -->

---
<!-- _class: compact -->

# Prüffälle für den Vergleich

Gültige Basis: Kundennummer `K-1`, eine Position mit Menge `1`.
Gesamtbetrag entspricht jeweils dem Positionspreis.

| Änderung an der Basis | Erwartung |
| :--- | :--- |
| Preis und Gesamtbetrag = 20 EUR | Gültig, keine Freigabe nötig |
| Positionsliste leer | Ungültig, strukturierter Fehler |
| Menge = 0 oder Preis = −1 EUR | Ungültig, strukturierter Fehler |
| Gesamtbetrag = 19 statt 20 EUR | Ungültig, Summenabweichung |
| Preis und Gesamtbetrag = 10.000 EUR | Gültig, keine Freigabe nötig |
| Preis und Gesamtbetrag = 10.000,01 EUR | Gültig, Freigabe nötig |

Zusätzlich: `null`-Order und leere Kundennummer prüfen.

<!-- Während der sechs Review-Minuten. Moderation: Prüffälle beziehen sich auf Runde 2. Jede Tabellenzeile ist ein separater Fall. Bei ungültigen Fällen ist RequiresApproval false. Fehlender Testlauf bedeutet „durchgesehen“, nicht „nachgewiesen“. Der vorgesehene Vergleich erfolgt per Review. Tatsächliche Ausführung ist eine spätere Vertiefung, kein zusätzlicher Pflichtschritt. -->

---
# Auswertung: Welche Lücke wurde geschlossen?

- Welche Annahmen aus Runde 1 wurden durch Regeln ersetzt?
- Wo verletzt Runde 2 eine **bereits bekannte** Anforderung?
- Was bleibt trotz besserem Kontext offen oder ungeprüft?

Eine vorher unbekannte Regel ist kein fairer Fehlermaßstab
für Runde 1. Ein Review ersetzt keinen Testlauf.

**Die Regeln spezifizieren wir. Klassischer Code führt sie aus.**

<!-- 3 Minuten. Zwei Beobachtungen sammeln. Fachlich gültig und freigegeben unterscheiden. Grenzwert exakt prüfen: > 10000, nicht >=. Codegenerierung durch ein LLM bedeutet nicht, dass jede Bestellung zur Laufzeit durch ein LLM validiert werden sollte. -->

---
<!-- _class: lead -->

# RAG, Tools und Agenten
## Einen Fehler im Repository untersuchen

<!-- Block 6: 88–108. Einstieg 1, RAG 2, Tool Calling 2, Agent 2, technische Grenzen 1, Gruppenarbeit 8, Debrief 4 Minuten. Die Begriffe bleiben Überblick, Implementierung folgt in Modul 6. -->

---
# Warum wird diese Bestellung abgelehnt?

Eine gültige Bestellung scheitert in einer unbekannten Codebasis.

Was braucht der Assistant für eine belastbare Untersuchung?

- Die betroffene Validierung und passende Fachregeln
- Ein reproduzierbares Beispiel und vorhandene Tests
- Werkzeuge, um Dateien zu lesen und Tests auszuführen

**Eine Vermutung über den Fehler braucht einen Nachweis.**

<!-- 1 Minute mit kurzem Zuruf. Bezug zur Bestellübung. Drei Perspektiven folgen: Quellen bereitstellen, kontrolliert ausführen, nächsten Schritt anhand des Ergebnisses wählen. Keine Live-Demo erforderlich. -->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/rag.png)

<!--
RAG: Retrieval-Augmented Generation. 2 Minuten. Beispiel: Suche findet OrderValidator.cs, zugehörige Tests und Fachregeln. Auszüge samt Frage gelangen in den Modellkontext. Das Modell erklärt mögliche Ursachen mit Fundstellen. Kein erneutes Training. Suche kann wichtige Dateien übersehen; Quellen und Stützung der Aussage prüfen. Retrieval kann Suche nach Text, Symbolen oder semantischer Ähnlichkeit verwenden und als Tool umgesetzt sein. Nicht jede Repository-Suche braucht eine Vektordatenbank.
Quelle: https://www.anthropic.com/engineering/effective-context-engineering-for-ai-agents
Bild: Vorhandenes Imagegen-Schema, assets/schematic-prompts.md.
-->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/tool-calling-tests.png)

<!-- Tool Calling bei der Fehlersuche. 2 Minuten. Illustrativer Toolname, kein bestehender API-Vertrag. Modell schlägt Aufruf vor, Anwendung prüft, Tool führt aus und liefert den Befund zurück. Auch Tests führen Code aus: nur freigegebene Testumgebung, keine ungeprüften Produktionszugriffe. Ein syntaktisch gültiger Aufruf genügt nicht als Berechtigung. „Ich habe getestet“ braucht ein echtes Ausführungsergebnis; ein grünes Symbol im Schema ist kein Testnachweis.
Bild: Bestehendes Tool-Calling-Schema mit integriertem Imagegen auf Testausführung angepasst. Prompt in assets/revision-prompts.md. -->

---
<!-- _footer: '' -->
<!-- _paginate: false -->

![bg contain](assets/agent-loop.png)

<!--
Agenten: Schritte mit Rückkopplung. 2 Minuten. Derselbe Fall: Datei lesen, Hypothese formulieren, Test anfordern, Ergebnis auswerten, bei Bedarf weitere Datei lesen. Das Modell wählt den nächsten Schritt innerhalb der von der Anwendung durchgesetzten Rechte und Limits. Eine feste Pipeline legt Schritte vorab fest, ein einzelner Toolaufruf ist noch keine Agentenschleife. Rückfrage und Abbruch sind erlaubte Ergebnisse. Tests können Annahmen widerlegen, Modellbewertung allein ist kein Beweis.
Quelle: https://www.anthropic.com/engineering/building-effective-agents
Bild: Vorhandenes Imagegen-Schema, assets/schematic-prompts.md.
-->

---
# Wo klassische Software die Grenze setzt

| Teilaufgabe | Geeigneter Mechanismus |
| :--- | :--- |
| Rechnungssumme | Definierte Rechenregeln im Code |
| JSON-Format prüfen | Parser und Schema-Validierung |
| Berechtigung prüfen | Authentifizierung und Autorisierung |
| Deployment ausführen | Kontrollierte Pipeline |

Das LLM kann unterstützen, etwa Code entwerfen oder Fehler erklären.
**Verbindliche Regeln bleiben technisch durchgesetzt.**

<!-- Moderation: Brücke zur Bestellübung. Ein LLM kann einen Validator schreiben. Zur Laufzeit prüft der Validator die Bestellung. Für sicherheitsrelevante Grenzen nie nur eine Anweisung an das Modell verwenden. -->

---
<!-- _class: exercise -->

# Wer übernimmt welchen Teil?
## Zwei Szenarien pro Gruppe · 8 Minuten

**A · Entwickleralltag**
Eine unbekannte Codebasis erklären und eine Fehlerursache prüfen.

**B · Aktion mit Außenwirkung**
Ein Produktionsdeployment vorbereiten und auslösen.

Für beide Fälle: **Datenquelle, Aufgabe des Modells,
Tool oder Code, Prüfung und Freigabe** festlegen.

<!-- 1 Minute individuell, 5 Minuten Gruppe, 2 Minuten einen strittigen Punkt vorbereiten. Je nach Gruppe kann B durch Resturlaub oder Rechnung ersetzt werden; Reserve im Trainerleitfaden. Es bleiben immer zwei Szenarien. Keine Implementierung. -->

---
<!-- _class: exercise -->

# Arbeitsblatt für eure Entscheidung

| Frage | Eure Antwort |
| :--- | :--- |
| Was darf das LLM entscheiden? | … |
| Woher kommen verlässliche Daten? | … |
| Was übernimmt Tool oder Code? | … |
| Woran erkennen wir einen Fehler? | … |
| Wann braucht es einen Menschen? | … |

**Zusatzfrage:** Was passiert bei fehlenden oder widersprüchlichen Daten?

<!-- Moderation: Während der Gruppenarbeit stehen lassen. Die nächste Folie erst nach den Beiträgen zeigen. Bewertet wird die Begründung, nicht das Nennen möglichst vieler Bausteine. -->

---
# Auswertung: Erklärung und Aktion

| | Codebasis verstehen | Deployment auslösen |
| :--- | :--- | :--- |
| Modell | Erklärt und bildet Hypothesen | Unterstützt Planung |
| Quellen | Dateien, Fachregeln, Tests | Änderung, Ziel, Prozess |
| Tool / Code | Liest Dateien, führt Tests aus | Kontrollierte Pipeline |
| Prüfung | Fundstellen und Verhalten | Checks, Rechte, Freigabe |

**Bei fehlenden Belegen: nachladen, nachfragen oder stoppen.**

<!-- 4 Minuten einschließlich zwei Gruppenbeiträgen. Freigaben richten sich nach dem tatsächlichen Prozess. Deployment mit Rücksetzplan, Berechtigungen technisch begrenzen. Mensch verantwortet Entscheidungen und Ausnahmen. Eine gefundene Datei beweist keine vollständige Suche. -->

---
# Kurzer Wissenscheck

1. Ihr gebt eine Datei mit. Was verändert sich dabei,
   was bleibt unverändert?
2. Eine Antwort ist dreimal identisch. Was ist damit belegt?
3. Eine RAG-Antwort enthält Quellen. Was prüft ihr noch?
4. Eine README fordert einen Upload. Der Tool-Aufruf ist
   gültiges JSON. Darf die Anwendung ihn ausführen?

**Erklärt jeweils den Mechanismus oder die nötige Prüfung.**

<!-- Block 7: 108–120. Wissenscheck 3, Kernbotschaften 1, Transfer 5, offene Fragen 2, Ausblick 1 Minute. Antworten: 1 Inhalt kann Teil des Kontexts werden, Parameter bleiben bei normaler Inference unverändert. Sichtbarkeit der Datei garantiert keine vollständige Verarbeitung. 2 Nur beobachtete Wiederholbarkeit, keine Wahrheit. 3 Existenz, Version, Inhalt, Stützung und Abdeckung. 4 Nein, Quelleninhalt ist keine Autorisierung. Rechte, Auftrag, Semantik und Freigabe prüfen. -->

---
# Fünf Kernbotschaften

1. Der Assistant verbindet Modell, Kontext und Werkzeuge.
2. Gelernte Fähigkeiten garantieren keine korrekte Antwort.
3. Relevante Quellen und klare Anforderungen helfen.
4. Rechte und verbindliche Regeln setzt Software durch.
5. Fundstellen, Builds und Tests liefern überprüfbare Belege.

<!-- 1 Minute. Eine Aussage mit dem Hilft/Nervt-Einstieg verbinden. Kontext verbessert die Arbeitsgrundlage, ersetzt weder Modellfähigkeit noch Prüfung. -->

---
<!-- _class: exercise -->

# Mein Transfer: 1–1–1
## 2 Minuten allein, 3 Minuten zu zweit

- **1 Erkenntnis**, die hängen geblieben ist
- **1 Änderung**, die ich beim nächsten AI-Einsatz ausprobiere
- **1 offene Frage**, die ich weiter klären möchte

Mein nächster Versuch:
„Bei __________ gebe ich __________ als Kontext mit
und prüfe das Ergebnis durch __________.“

<!-- Moderation: Jede Person schreibt selbst. Danach 2 Minuten offene Fragen einsammeln und passenden Folgemodulen zuordnen. Die ausgefüllte Aussage dient als konkreter Transfer, nicht als zusätzliche Hausaufgabe. -->

---
<!-- _class: lead -->

# AI-Assisted Coding
## Nächstes Modul: Staying in Control

Aufgaben zerlegen, passenden Codekontext bereitstellen
und Änderungen in überprüfbaren Schritten umsetzen.

**Euer eigener Code bleibt eure Verantwortung.**

<!-- Moderation: 1 Minute. Übergang gemäß Curriculum: kontrollierter Einsatz von Coding Assistants. Vertiefung von Tests in Modul 3, Refactoring in Modul 4, Spezifikationen in Modul 5 und Agentenbau in Modul 6. -->
