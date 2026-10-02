# Lösungshinweise · Modul 6

Ergänzung zum [Trainerleitfaden](modul-6-leitfaden.md). Ausschnitte sind Integrationshilfen für das lokale Starterprojekt, keine vollständige Lösung. Mit den jeweiligen `using`-Direktiven in die genannten Stellen einfügen und lokal bauen und prüfen.

## Runde 1: Suchtools

In `AgentFactory.Create(...)` ergänzen:

```csharp
var searchFlights = AIFunctionFactory.Create(
    travelService.SearchFlights,
    name: "search_flights",
    description: "Search flights by origin and destination city names and travel dates. " +
                 "The training dataset filters by cities only; dates are not enforced.");

var searchHotels = AIFunctionFactory.Create(
    travelService.SearchHotels,
    name: "search_hotels",
    description: "Search available hotels by city name and maximum price per night in EUR.");
```

Beide zur bestehenden `tools`-Liste hinzufügen. Destination-Codes nicht als Stadtnamen übergeben. Beobachtete Tool-Ausgaben und Empfehlung vergleichen, keine feste Reihenfolge als Erfolgskriterium verlangen.

## Runde 2: Hotelbuchung hinter Freigabe

In `AgentFactory.Create(...)` ergänzen und nur diesen Wrapper als Tool registrieren:

```csharp
var bookHotel = AIFunctionFactory.Create(
    (string hotelId) =>
    {
        if (approvalService.PendingApproval is not null)
        {
            return "Another booking awaits approval. Do not submit another request.";
        }

        var hotel = travelService.GetHotel(hotelId);
        if (hotel is null)
        {
            return $"Hotel '{hotelId}' does not exist.";
        }

        approvalService.RequestApproval(new PendingApproval(
            $"Book hotel {hotel.Id}: {hotel.Name}, {hotel.PricePerNight} EUR per night.",
            () => travelService.BookHotel(hotelId)));

        return "Booking requested, awaiting human approval. It is not confirmed.";
    },
    name: "book_hotel",
    description: "Request one hotel booking by a previously retrieved hotel ID. " +
                 "Execution requires human approval; this tool does not confirm a booking.");
```

Flugbuchung analog: Kandidaten mit `SearchFlights` anhand von Städten und Datumsparametern ermitteln, die ausgewählte ID mit den Ergebnissen abgleichen und `PendingApproval` mit `() => travelService.BookFlight(flightId)` hinterlegen. Keine nicht vorhandene `GetFlight`-Methode verwenden. Preis und Flugidentität aus dem API-Ergebnis beschreiben.

Der Guard verhindert das Überschreiben einer bereits offenen Anfrage in diesem Wrapper. Für beide Booking-Wrapper verwenden. Er ersetzt keine Queue oder Synchronisation. Der bestehende Freigabepfad löscht nach der Agent-Wiederaufnahme die offene Anfrage; dabei können Folgeanfragen verloren gehen. Deshalb in der Übung eine Aktion pro Nutzerturn und nach Wiederaufnahme nur das Ergebnis berichten lassen. Robuste Erweiterung: Freigabe vor Wiederaufnahme atomar entnehmen und neue Anfragen anschließend separat verarbeiten.

## Runde 3: Runtime-Polling

Einfache synchrone Lösung für den vorhandenen TODO in `Program.cs`:

```csharp
static BookingResult waitForBookingToFinish(
    TravelService travelApi, BookingResult result)
{
    var bookingId = result.BookingId;
    while (result.Status == BookingStatus.Pending)
    {
        Thread.Sleep(2000);
        result = travelApi.GetBookingStatus(bookingId)
            .GetAwaiter().GetResult();
        Console.WriteLine($"[RUNTIME] Booking {bookingId}: {result.Status}");
    }
    return result;
}
```

Das ist eine blockierende Konsolenlösung ohne Gesamt-Timeout. Alternative: Den vorhandenen asynchronen Monitor aus `AIAgentTraining.Runtime` nutzen. Im `humanApproval`-Pfad nach `approval.Action()` den bisherigen Polling-Aufruf ersetzen:

```csharp
if (result.Status == BookingStatus.Pending)
{
    var monitor = new AIAgentTraining.Runtime.BookingMonitor(travelApi!);
    using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));
    result = await monitor.WaitForCompletionAsync(
        result.BookingId, cancellationToken: timeout.Token);
}
```

Für diese Alternative auch den Abbruch behandeln: `OperationCanceledException` bedeutet unbekannten Endzustand, nicht fehlgeschlagene Buchung. Booking-ID erhalten, später Status erneut abfragen und nicht blind neu buchen. Ein produktiver Ablauf benötigt dauerhaft gespeicherten Zustand. Das `!` folgt dem aktuellen Aufrufer, der immer eine `TravelService`-Instanz übergibt; bei weiterer Verwendung den nullable Vertrag bereinigen.

Im Wiederaufnahme-Prompt neben Booking-ID und Status bei Bedarf `result.Price` ergänzen. Dieser Wert allein implementiert keine Preisfreigabe vor Buchung.

## Runde 4: Teilfehler

In `FailedHotelBooking` bestätigt die API den Flug und liefert für Hotelbuchungen `Failed`. Ergebnis in derselben Session berichten. Alternative Unterkunft, Flug behalten oder Stornierung sind Vorschläge, keine bereits ausgeführten Aktionen. Keine Transaktion über beide Buchungen behaupten. Für ein neues Stornierungstool ebenfalls ID prüfen und eine eigenständige menschliche Freigabe verlangen.

## Prüfhinweise

- Suchtools liefern bekannte IDs und Preise; Empfehlung benennt Annahmen.
- Booking-Anfrage und Ablehnung rufen keine Booking-API auf; Zustimmung führt genau die freigegebene Aktion aus.
- Ein terminales Eingangsergebnis benötigt kein Polling. Pending wird von der Runtime verfolgt; alle terminalen Status beenden das Warten.
- Agent berichtet API-Zustand, nicht eine vermutete Bestätigung.
- Teilfehler behalten ihren tatsächlichen Zustand; Recovery-Aktionen benötigen eine eigene Grenze.

Toolwahl und Formulierung bleiben modellabhängig. Buchungsstatus und Runtime-Verhalten lassen sich ohne Modell prüfen.
