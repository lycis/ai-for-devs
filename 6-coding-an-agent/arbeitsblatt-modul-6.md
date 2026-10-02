# Arbeitsblatt · Modul 6

Team: ____________________  Coding Agent / Modell: ____________________

## Travel Agent

Ein C#-Reiseassistent sucht Ziele, Flüge und Hotels in einer fiktiven Travel API. Ihr ergänzt Tools, führt Buchungen über menschliche Freigabe aus und verarbeitet externe Buchungszustände.

Im vorbereiteten Projekt `AIAgentTraining/` arbeiten. Setup siehe [README](README.md). Nur freigegebene Zugänge und synthetische Daten verwenden. Keine API-Keys in Prompts oder Beobachtungen übernehmen. Die Travel API ist fiktiv; Modellaufrufe nutzen den konfigurierten Provider.

Die Runden bauen aufeinander auf. Änderungen behalten, Rollen je Runde wechseln: Driver implementiert und bedient die Konsole, Navigator prüft Diff, Verhalten und Ausgaben. Eine dritte Person beobachtet bei Bedarf. Vor Szenariowechseln den Prozess beenden, `SetScenario(...)` in `Program.cs` ändern und neu starten. `exit` beendet die Konsole; ein Neustart setzt Session und In-Memory-Buchungen zurück.

## Runde 1 · 20 Minuten

Etwa 3 Minuten Schnittstellen lesen, 12 Minuten implementieren und ausführen, 5 Minuten reflektieren.

In `AgentFactory.cs` die bestehenden Methoden `TravelService.SearchFlights` und `TravelService.SearchHotels` mit `AIFunctionFactory.Create(...)` als Tools registrieren und in die Toolliste aufnehmen. Klare Namen und Beschreibungen wählen. Die vorhandene Destination-Suche als Muster nutzen.

Kopierbarer Nutzerprompt für die Reisekonsole:

```text
Ich suche ein warmes Wochenendziel ab Vienna für ein Budget von 1.000 €.
Nutze die fiktiven Reisedaten. Gehe für den Vergleich von zwei Hotelnächten
und dem angezeigten Flugpreis aus; behaupte keinen enthaltenen Rückflug.
Suche passende Ziele, Flüge und Hotels und begründe eine Empfehlung.
Benenne fehlende Angaben und buche noch nichts.
```

Die Flugsuche akzeptiert Daten, filtert im Starter aber nur nach Abflug- und Zielort. Destination-ID und Stadtname unterscheiden; die Flug- und Hotelsuche benötigt Stadtnamen. Ergebnis als Vergleich der Beispieldaten behandeln.

Welche Tools wurden tatsächlich aufgerufen? _________________________

Welche Preise / IDs stützen die Empfehlung? _________________________

Welche Annahme hat das Modell getroffen? ___________________________

Was würdet ihr an einer Toolbeschreibung ändern? _____________________

## Runde 2 · 20 Minuten

Etwa 4 Minuten Freigabepfad verstehen, 11 Minuten implementieren und prüfen, 5 Minuten reflektieren.

Booking-Tools für `BookFlight` und `BookHotel` ergänzen. Keine direkte Buchungsmethode als Agenttool exponieren: Ein Wrapper validiert die ausgewählte ID und legt mit `ApprovalService.RequestApproval(...)` eine `PendingApproval` an. Deren Delegate führt erst nach Zustimmung die API-Buchung aus. `Program.cs` enthält den Freigabedialog bereits.

Nur eine Buchung pro Nutzerturn anfordern: Der Starter hält nur eine offene Freigabe. Folgeaktionen in einem neuen Nutzerturn starten.

Kopierbarer Prompt; Platzhalter durch eine tatsächlich gefundene Hotel-ID ersetzen:

```text
Fordere die Buchung des Hotels <HOTEL-ID> an.
Stelle genau diese eine Buchungsanfrage. Nach der Freigabe berichte
nur das Ergebnis und fordere keine weitere Buchung an.
```

Einmal ablehnen, danach in einem neuen Turn erneut anfordern und zustimmen. In den API-Ausgaben prüfen, wann `BookHotel` tatsächlich aufgerufen wurde. Für einen Flug denselben Ablauf mit einer gefundenen Flug-ID verwenden.

Bis ihr in Runde 3 den Status abfragt, bleibt das Buchungsergebnis `Pending`, auch im Szenario `HappyPath`. Eine ausgeführte Anfrage ist noch keine bestätigte Buchung.

| Prüfung | Beobachtung / Codestelle |
| --- | --- |
| Anfrage erzeugt noch keine API-Buchung | |
| Ablehnung erzeugt keine API-Buchung | |
| Zustimmung führt die konkret beschriebene Aktion aus | |
| Ungültige ID führt zu keiner Buchung | |

Welche Grenze wird durch Code durchgesetzt? ________________________

Was würde bei zwei offenen Anfragen passieren? ______________________

Welche Grenze lässt sich nicht durch eine Promptregel garantieren? _______

## Runde 3 · 30 Minuten

Etwa 5 Minuten Pending-Verhalten ansehen, 15 Minuten Runtime ergänzen, 5 Minuten prüfen, 5 Minuten reflektieren.

In `Program.cs` setzen:

```csharp
travelApi.SetScenario(TravelApiScenario.DelayedBookingConfirmation);
```

`waitForBookingToFinish(...)` vervollständigen:

1. Bereits terminales Ergebnis direkt zurückgeben.
2. Bei `Pending` den Status derselben Booking-ID über `GetBookingStatus(...)` abfragen.
3. Zwischen weiteren Abfragen warten.
4. Bei `Confirmed`, `Failed` oder `Cancelled` stoppen und das Ergebnis zurückgeben.

Alternative: Den bereits fertigen `BookingMonitor.WaitForCompletionAsync(...)` integrieren und den Freigabepfad auf `await` umstellen. Warten gehört in die Runtime; der Agent soll nicht wiederholt Status-Tools aufrufen.

Eine einzelne Buchung anfordern und freigeben. Beobachten, wie `humanApproval` das finale Ergebnis an dieselbe Agent-Session zurückgibt.

| Beobachtung | Konkreter Beleg |
| --- | --- |
| Statusfolge für dieselbe Booking-ID | |
| Warten / Statusabfrage erfolgt ohne Modellaufruf | |
| Runtime stoppt bei terminalem Status | |
| Agent erhält Ergebnis und berichtet den tatsächlichen Status | |

Was passiert bei dauerhaftem Pending? ______________________________

Was geht bei einem Prozessneustart verloren? ________________________

Welche Information enthält das Ergebnis, aber bisher nicht der Wiederaufnahme-Prompt? __________________________________________________

## Runde 4 · 15 Minuten

Etwa 2 Minuten Szenario vorbereiten, 8 Minuten beobachten, 5 Minuten auswerten.

```csharp
travelApi.SetScenario(TravelApiScenario.FailedHotelBooking);
```

Neu starten. Zuerst einen Flug einzeln anfordern und freigeben. Danach ein Hotel einzeln anfordern und freigeben. Den Status beider Aktionen notieren.

Kopierbarer Prompt nach dem Hotelresultat:

```text
Die Hotelbuchung ist fehlgeschlagen, der Flug wurde bereits bestätigt.
Erkläre die aktuelle Situation und schlage nächste Schritte vor.
Führe keine weitere Buchung oder Stornierung aus. Frage nach,
wenn eine Entscheidung von meinen Präferenzen abhängt.
```

Flug-ID / Status: ______________  Hotelbuchung-ID / Status: ______________

Welche Option schlägt der Agent vor, mit welcher Begründung? ___________

Welche Zustimmung wäre vor einer Folgeaktion nötig? __________________

Dieses Szenario lässt Hotelbuchungen generell scheitern. Ein anderes Hotel garantiert keinen Erfolg. `CancelBooking` existiert in der API, ist aber noch kein Agenttool. Eine Stornierung zunächst als Entwurf besprechen.

## Produktionsfragen · 10 Minuten

**Duplikate:** Eine Buchungsanfrage endet mit einem Timeout. Ist sicher, dass nichts gebucht wurde? Wer verhindert eine zweite Ausführung derselben Anfrage?

Unsere Antwort und nötige technische Maßnahme: _____________________

**Preisänderung:** Die Suche nennt 85 € pro Nacht, die Buchung 110 €. Welche Quelle zählt? Wo muss die genehmigte Preisgrenze geprüft werden und wann braucht es eine neue Freigabe?

Unsere Antwort und nötige technische Maßnahme: _____________________

Beide Fälle sind Diskussionen; der Starter besitzt weder ein Preisänderungsszenario noch Idempotenzschlüssel.

## Unser Architekturvergleich · 3 Minuten

Ordnet Verantwortung zu und nennt einen Beleg aus euren Runden. Mehrere Beteiligte sind möglich; beschreibt die Grenze.

| Aufgabe | Agent / Runtime / Mensch oder Policy | Konkreter Beleg |
| --- | --- | --- |
| Nutzerwunsch interpretieren | | |
| Alternativen vergleichen | | |
| Verlässliche Preise und Zustände liefern | | |
| Ausgabe freigeben | | |
| Buchung ausführen | | |
| Warten und Status verfolgen | | |
| Doppelte Ausführung verhindern | | |
| Recovery auswählen und genehmigen | | |
| Zustand nach Neustart wiederherstellen | | |

Was hat funktioniert? _____________________________________________

Welche Grenze des Starters haben wir tatsächlich beobachtet? ___________

## Mein Transfer · 3 Minuten

Meine nächste Änderung am eigenen Anwendungsdesign: _______________

Bei __________ überlasse ich dem Agenten __________; die Runtime erzwingt __________ und prüft das Ergebnis durch __________.

Welche offene Frage bleibt für ein Produktionssystem? _________________
