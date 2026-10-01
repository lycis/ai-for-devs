using AIAgentTraining.Models;
using AIAgentTraining.TravelApi;

namespace AIAgentTraining.Runtime;

public sealed class BookingMonitor
{
    private readonly ITravelApi _travelApi;

    public BookingMonitor(ITravelApi travelApi)
    {
        _travelApi = travelApi;
    }

    public async Task<BookingResult> WaitForCompletionAsync(
        string bookingId,
        TimeSpan? pollingInterval = null,
        CancellationToken cancellationToken = default)
    {
        var interval =
            pollingInterval ?? TimeSpan.FromSeconds(2);

        Console.WriteLine(
            $"[RUNTIME] Monitoring booking {bookingId}...");

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var booking =
                await _travelApi.GetBookingStatus(bookingId);

            Console.WriteLine(
                $"[RUNTIME] Booking {booking.BookingId}: {booking.Status}");

            if (booking.Status != BookingStatus.Pending)
            {
                Console.WriteLine(
                    $"[RUNTIME] Booking {booking.BookingId} reached terminal state: " +
                    $"{booking.Status}");

                return booking;
            }

            Console.WriteLine(
                $"[RUNTIME] Booking still pending. " +
                $"Checking again in {interval.TotalSeconds:0.#} seconds...");

            await Task.Delay(
                interval,
                cancellationToken);
        }
    }
}