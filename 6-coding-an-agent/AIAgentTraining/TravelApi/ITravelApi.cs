using AIAgentTraining.Models;

namespace AIAgentTraining.TravelApi
{
    public interface ITravelApi
    {
        Task<IReadOnlyList<Destination>> SearchDestinations(decimal minimumTemperatureCelsius, decimal maxBudget);

        Task<IReadOnlyList<Flight>> SearchFlights(string from, string to, DateOnly departure, DateOnly returnDate);

        Task<IReadOnlyList<Hotel>> SearchHotels(string city, decimal maxNightlyRate);

        Task<BookingResult> BookHotel(string hotelId);

        Task<BookingResult> BookFlight(string flightId);

        Task<BookingResult> GetBookingStatus(string bookingId);

        Task<BookingResult> CancelBooking(string bookingId);
    }
}
