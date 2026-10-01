 ## Lookup Functions
  ```csharp AgentFactory.cs
 var searchHotels = AIFunctionFactory.Create(```
     travelService.SearchHotels,
     name: "search_hotels",
     description:
         """
         Search for a hotel in a city with a maximum rate per night.
         """
 );
 ``` 

## Hotel Booking
```csharp AgentFactory.cs
 var bookHotel = AIFunctionFactory.Create(
     (string hotelId) =>
     {
         var hotel = travelService.GetHotel(hotelId);

         if (hotel is null)
         {
             return $"Hotel '{hotelId}' does not exist.";
         }

         approvalService.RequestApproval(
             new PendingApproval(
                 $"The agent wants to book {hotel.Name} for {hotel.PricePerNight}€ per night.",
                 async () => await travelService.BookHotel(hotelId)
         ));

         return
             $"Booking '{hotel.Name}' requires human approval. " +
             "The request has been submitted for approval.";
     },
     name: "book_hotel",
     description: "Requests booking of a hotel by hotel ID. The booking requires human approval."
  );
```

## Hotel Booking with Waiting for Confirmation
```csharp Program.cs
static BookingResult waitForBookingToFinish(TravelService travelApi, BookingResult result)
{
    var bookingId = result.BookingId
    while (true)
    {
        var result = travelApi
            .GetBookingStatus(bookingId)
            .GetAwaiter()
            .GetResult();

        Console.WriteLine(
            $"[RUNTIME] Booking {bookingId}: {result.Status}");

        if (result.Status != BookingStatus.Pending)
        {
            return result;
        }

        Thread.Sleep(2000);
    }
}
```