# Trainerleitfaden · Modul 6

## Ziel und Vorbereitung

Die Teilnehmenden bauen einen Reiseassistenten mit mehreren Tools, verankern Freigaben außerhalb des Modells und unterscheiden agentische Entscheidungen von deterministischer Zustandsverwaltung. Teams aus zwei oder drei Personen, C#/.NET-Vorkenntnisse. Driver und Navigator wechseln pro Runde; eine dritte Person beobachtet bei Bedarf.

Vorab .NET-10-SDK, Paketwiederherstellung, Providerzugang und Start aus `AIAgentTraining/` prüfen. `.env.example` als lokale `.env` mit freigegebenem Key verwenden. Arbeitsblatt, Timer und gemeinsame Sammelfläche bereithalten. Keine echten Reisebuchungen; die API ist fiktiv. Die Modellaufrufe benötigen den Providerzugang. Ohne Zugang Tools und Runtime lokal prüfen sowie Tool-Aufrufe auf Papier nachvollziehen; agentische Auswahl bleibt dann unbeobachtet.

Das Starterprojekt und die [Lösungshinweise](Solutions.md) vorab lesen. `AgentFactory.cs` enthält zunächst nur `search_destinations`. In `Program.cs` stehen Szenarioauswahl, Freigabe und Wiederaufnahme in derselben Session. Der Polling-TODO heißt `waitForBookingToFinish`; der separate `BookingMonitor` ist bereits vollständig implementiert. DTOs und Fake API werden nicht neu geschrieben.

## Ablauf und Moderation

| Zeit | Material | Durchführung |
| --- | --- | --- |
| 00:00–00:10 | Starter / Demo | 3 Min Leitfrage und Ziel, 4 Min Demo mit Destination-Tool, 3 Min Modell, Instructions, Tools und Session zuordnen. |
| 00:10–00:30 | Runde 1 | 3 Min Tool-Schnittstellen lesen, 12 Min Suchtools integrieren und ausführen, 5 Min Beobachtungen vergleichen. |
| 00:30–00:50 | Runde 2 | 4 Min Freigabegrenze erklären, 11 Min Booking-Wrapper implementieren und Zustimmung/Ablehnung prüfen, 5 Min auswerten. |
| 00:50–01:20 | Runde 3 | 5 Min Pending-Demo, 15 Min Poller implementieren oder Monitor integrieren, 5 Min Zustände und Wiederaufnahme prüfen, 5 Min auswerten. |
| 01:20–01:35 | Runde 4 | 2 Min Teilfehler setzen, 8 Min einzelne Buchungen und Recovery beobachten, 5 Min Zuständigkeiten diskutieren. |
| 01:35–01:45 | Produktionsfragen | Je 5 Min Duplikate/Idempotenz und Preisänderung diskutieren. |
| 01:45–01:52 | Harness-Impuls | 4 Min Planung und Kontextmanagement, 3 Min Providergrenzen und offene Runtime-Aufgaben. |
| 01:52–02:00 | Vergleich / Transfer | 3 Min Zuständigkeiten, 3 Min Transfer im Pair, 2 Min gemeinsame Kernbotschaft und Fragen. |

Die 120 Minuten enthalten keine separate Pause. Bei Verzögerung die optionalen Harness-Details kürzen, Übungs- und Reflexionszeit schützen. Setup erfolgt vorab. Die vier Runden verwenden dasselbe Projekt und dieselbe Gruppe; neue Konsolenläufe beginnen mit frischer Session und frischem In-Memory-Zustand.

## Hinweise je Runde

**Runde 1:** `SearchFlights` und `SearchHotels` über `AIFunctionFactory.Create(...)` exponieren und der Toolliste hinzufügen. Namen, Beschreibungen und Parameter sind die Schnittstelle des Modells. Tool-Ergebnisse mit der Empfehlung vergleichen. Keine feste Toolreihenfolge verlangen: Ein geeignetes Ergebnis darf über unterschiedliche Wege entstehen. Reiseziel-Codes und Stadtnamen unterscheiden; `SearchFlights` und `SearchHotels` erwarten Namen. Der Fake-Datensatz enthält feste Beispieldaten, und die Flugsuche filtert nicht nach Datum. Preise stammen aus Tools, die API modelliert keine vollständige Hin- und Rückreise. Für die Budgetrechnung Annahmen, etwa Zahl der Nächte, sichtbar machen.

**Runde 2:** Keine direkten `BookFlight`-/`BookHotel`-Methoden als Agenttools registrieren. Wrapper prüfen die ID, beschreiben die konkrete Aktion und hinterlegen eine `PendingApproval` mit Ausführungsdelegate. Erst `humanApproval` führt nach Zustimmung aus. Hotelinformationen liefert `GetHotel`; Fluginformationen können aus `SearchFlights` stammen. Nicht erfundene Lookup-Methoden voraussetzen. Ablehnung muss ohne Booking-Aufruf auskommen. Die Freigabebeschreibung darf nur die vom Starter tatsächlich unterstützten Leistungen zusagen: `BookHotel` erhält nur eine ID, keinen Aufenthalt oder Gesamtpreis.

Der Starter hält genau eine `PendingApproval`. Neue Anforderungen können sie überschreiben; Freigaben aus einer Agent-Wiederaufnahme können durch das abschließende `ClearPendingApproval()` verloren gehen. Deshalb je Nutzerturn nur eine Buchung anfordern, Agent nach Freigabe zum Berichten auffordern und Folgeaktionen erst in einem neuen Nutzerturn starten. Das ist eine Übungskonvention, keine technische Garantie. Nicht als robuste Multi-Booking-Lösung darstellen. Queue, atomare Entnahme und wiederholte Freigabeverarbeitung sind mögliche Vertiefungen.

Die API legt jede Buchung zunächst als `Pending` an, auch in `HappyPath`. Erst `GetBookingStatus` liefert den Szenario-Endzustand. Vor Runde 3 bleibt der Polling-TODO unverändert und meldet daher noch `Pending`; Erfolg in Runde 2 ist die korrekt freigegebene Ausführung, keine bestätigte Buchung.

**Runde 3:** `TravelApiScenario.DelayedBookingConfirmation` in `Program.cs` setzen. Bei `Pending` denselben Booking-ID-Status abfragen, zwischen Abfragen warten und bei `Confirmed`, `Failed` oder `Cancelled` zurückkehren. Ein terminales Eingangsergebnis direkt zurückgeben. Modell nicht zum Polling auffordern. Wahlweise den vorhandenen `BookingMonitor.WaitForCompletionAsync` integrieren; dafür den Aufruf im Freigabepfad auf `await` umstellen. Der synchrone TODO ist für die kleine Konsolenübung möglich. Timeout, Cancellation und Prozessneustart als Grenzen benennen. Der vorhandene Monitor unterstützt Cancellation, aber keinen Gesamt-Timeout und keine persistente Wiederaufnahme.

`humanApproval` liefert Status und ID in dieselbe Agent-Session zurück. Gemeinsam prüfen, dass erst nach terminalem Ergebnis „bestätigt“ berichtet wird. Preis steht im `BookingResult`, wird im bisherigen Wiederaufnahme-Prompt aber nicht mitgegeben; für einen Preisvergleich muss dieser ergänzt werden. Gesprächszustand ist kein dauerhafter Buchungsspeicher.

**Runde 4:** `TravelApiScenario.FailedHotelBooking` setzen und Prozess neu starten. Einen Flug separat buchen und freigeben, danach ein Hotel separat buchen und freigeben. Bei fehlgeschlagenem Hotel bleibt der Flug bestätigt. Der Agent darf Alternativen vorschlagen oder nachfragen; der Starter darf keine automatische Gesamttransaktion behaupten. In diesem Szenario scheitern Hotelbuchungen generell, auch ein anderes Hotel führt nicht automatisch zum Erfolg. `CancelBooking` existiert in der API, ist aber noch kein Agenttool. Stornierung daher zunächst diskutieren; eine Integration benötigt eine eigene Freigabegrenze.

## Reflexion ohne vorgegebene Antwort

Mit konkreten Tool-Aufrufen, Runtime-Ausgaben oder Codestellen argumentieren. Wenn das Modell einen falschen Parameter wählt, Toolvertrag, Beschreibung und Nutzereingabe prüfen. Wenn keine Tools gewählt werden, Sichtbarkeit und Instructions untersuchen. Nicht jede Empfehlung hat eine eindeutige richtige Antwort. Ein plausibler Text belegt keine Buchung; der API-Status ist maßgeblich.

Leitfragen: Welche Entscheidung braucht Abwägung? Welche Regel kann Code erzwingen? Was bleibt nach einem Neustart erhalten? Welche beobachtete Grenze müsste vor Produktion behoben werden?

## Produktionsfragen und Harness

**Duplikate:** Ein Timeout beweist nicht, dass keine Buchung entstanden ist. Derselbe Geschäftsvorgang benötigt einen stabilen Idempotenzschlüssel und serverseitige Deduplizierung. Der Starter implementiert beides nicht; keine Promptregel als Ersatz darstellen.

**Preisänderung:** Diskussionsfall „85 € gesucht, 110 € bei Buchung“. Das externe System liefert den tatsächlichen Preis. Runtime muss die genehmigte Preisgrenze vor einer verbindlichen Aktion durchsetzen; bei Überschreitung neu entscheiden lassen. Nachträgliches Berichten ersetzt keine vorherige Freigabe. Dieses Verhalten ist kein eingebautes Szenario.

**Harness:** Planung, Aufgabenverwaltung und Kontextmanagement unterstützen längere Agentaufgaben. Persistenz, Scheduling, Idempotenz und Freigabepolicy bleiben Anwendungsaufgaben. Keine zusätzliche Harness-Integration verlangen. Providerabhängige Optionen nur demonstrieren, wenn vorab mit den lokal verwendeten Paketen geprüft; die alte Outline ist kein Nachweis aktueller Kompatibilität.

## Abschluss und Transfer

Die Verantwortungstabelle im Arbeitsblatt ausfüllen. Modell: Intent, Vergleich, nächste sinnvolle Anfrage und Erklärung. Runtime: Toolausführung, Autorisierung, Polling, Zustände und Zuverlässigkeit. Mensch/Policy: Budget, folgenreiche Freigaben und subjektive Präferenzen. Eine konkrete Änderung am eigenen Anwendungsdesign notieren lassen.

Optionale Vertiefung ersetzt andere Arbeit: Poller ohne Modell testen; Approval-Queue entwerfen; Prozessneustart mit dauerhaftem Zustand planen. Diese Aufgaben sind kein Pflichtumfang der zwei Stunden.

## Fachreferenzen und Material

- [Starterprojekt](../AIAgentTraining/), besonders [AgentFactory.cs](../AIAgentTraining/AgentFactory.cs), [Program.cs](../AIAgentTraining/Program.cs) und [TravelService.cs](../AIAgentTraining/TravelApi/TravelService.cs): maßgebliche lokale Schnittstellen.
- [Arbeitsblatt](../arbeitsblatt-modul-6.md) und [Lösungshinweise](Solutions.md).
- [Ursprüngliche Outline](LESSON_PLAN.md): didaktischer Hintergrund und weitergehende Entwürfe.
- [Curriculum](../../Curriculum.md): Lernziele und Anschluss an die vorangehenden Module.
