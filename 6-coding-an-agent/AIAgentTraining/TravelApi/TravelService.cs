using AIAgentTraining.Models;

namespace AIAgentTraining.TravelApi
{
    public enum TravelApiScenario
    {
        HappyPath,
        DelayedBookingConfirmation,
        FailedHotelBooking
    }

    public class TravelService : ITravelApi
    {
        private TravelApiScenario _scenario = TravelApiScenario.HappyPath;

        public void SetScenario(TravelApiScenario scenario)
        {
            _scenario = scenario;
        }

        private readonly List<Destination> _destinations =
        [
            new(
                Id: "PMI",
                Name: "Palma",
                Country: "Spain",
                TemperatureCelsius: 25,
                TypicalWeekendCost: 700m),

            new(
                Id: "LIS",
                Name: "Lisbon",
                Country: "Portugal",
                TemperatureCelsius: 23,
                TypicalWeekendCost: 850m),

            new(
                Id: "ATH",
                Name: "Athens",
                Country: "Greece",
                TemperatureCelsius: 27,
                TypicalWeekendCost: 950m),

            new(
                Id: "BER",
                Name: "Berlin",
                Country: "Germany",
                TemperatureCelsius: 20,
                TypicalWeekendCost: 600m),

            new(
                Id: "OSL",
                Name: "Oslo",
                Country: "Norway",
                TemperatureCelsius: 15,
                TypicalWeekendCost: 600m)
        ];

        private readonly List<Flight> _flights =
        [
            new(
                Id: "OS101",
                From: "Vienna",
                To: "Palma",
                Departure: new DateTime(2026, 9, 11, 8, 10, 0),
                Arrival: new DateTime(2026, 9, 11, 10, 40, 0),
                Price: 189m),

            new(
                Id: "FR201",
                From: "Vienna",
                To: "Palma",
                Departure: new DateTime(2026, 9, 11, 17, 45, 0),
                Arrival: new DateTime(2026, 9, 11, 20, 20, 0),
                Price: 139m),

            new(
                Id: "TP301",
                From: "Vienna",
                To: "Lisbon",
                Departure: new DateTime(2026, 9, 11, 7, 30, 0),
                Arrival: new DateTime(2026, 9, 11, 10, 15, 0),
                Price: 229m),

            new(
                Id: "TP302",
                From: "Vienna",
                To: "Lisbon",
                Departure: new DateTime(2026, 9, 11, 15, 20, 0),
                Arrival: new DateTime(2026, 9, 11, 18, 10, 0),
                Price: 179m),

            new(
                Id: "A3401",
                From: "Vienna",
                To: "Athens",
                Departure: new DateTime(2026, 9, 11, 9, 0, 0),
                Arrival: new DateTime(2026, 9, 11, 12, 10, 0),
                Price: 249m),

            new(
                Id: "A3402",
                From: "Vienna",
                To: "Athens",
                Departure: new DateTime(2026, 9, 11, 18, 15, 0),
                Arrival: new DateTime(2026, 9, 11, 21, 25, 0),
                Price: 199m),

            new(
                Id: "OS501",
                From: "Vienna",
                To: "Berlin",
                Departure: new DateTime(2026, 9, 11, 10, 20, 0),
                Arrival: new DateTime(2026, 9, 11, 11, 35, 0),
                Price: 149m),

            new(
                Id: "DY601",
                From: "Vienna",
                To: "Oslo",
                Departure: new DateTime(2026, 9, 11, 6, 50, 0),
                Arrival: new DateTime(2026, 9, 11, 9, 10, 0),
                Price: 169m)
        ];

        private readonly List<Hotel> _hotels =
        [
            new(
                Id: "PMI-H1",
                City: "Palma",
                Name: "Palma Central Hotel",
                PricePerNight: 145m,
                Rating: 4.5m,
                Available: true),

            new(
                Id: "PMI-H2",
                City: "Palma",
                Name: "Mediterranean Family Inn",
                PricePerNight: 95m,
                Rating: 4.1m,
                Available: true),

            new(
                Id: "LIS-H1",
                City: "Lisbon",
                Name: "Lisbon Riverside Hotel",
                PricePerNight: 155m,
                Rating: 4.6m,
                Available: true),

            new(
                Id: "LIS-H2",
                City: "Lisbon",
                Name: "Alfama Guesthouse",
                PricePerNight: 110m,
                Rating: 4.3m,
                Available: true),

            new(
                Id: "ATH-H1",
                City: "Athens",
                Name: "Acropolis View Hotel",
                PricePerNight: 165m,
                Rating: 4.7m,
                Available: true),

            new(
                Id: "ATH-H2",
                City: "Athens",
                Name: "Athens Family Stay",
                PricePerNight: 105m,
                Rating: 4.0m,
                Available: true),

            new(
                Id: "BER-H1",
                City: "Berlin",
                Name: "Berlin Mitte Hotel",
                PricePerNight: 120m,
                Rating: 4.4m,
                Available: true),

            new(
                Id: "OSL-H1",
                City: "Oslo",
                Name: "Oslo Harbour Hotel",
                PricePerNight: 175m,
                Rating: 4.5m,
                Available: true)
        ];

        private readonly Dictionary<string, BookingState> _bookings = [];

        private int _nextBookingId = 1;

        public Task<IReadOnlyList<Destination>> SearchDestinations(
            decimal minimumTemperatureCelsius,
            decimal maxBudget)
        {
            Console.WriteLine(
                $"[API] SearchDestinations(" +
                $"minimumTemperatureCelsius={minimumTemperatureCelsius}, " +
                $"maxBudget={maxBudget})");

            IReadOnlyList<Destination> results = _destinations
                .Where(d =>
                    d.TemperatureCelsius >= minimumTemperatureCelsius &&
                    d.TypicalWeekendCost <= maxBudget)
                .ToList();

            Console.WriteLine(
                $"[API] -> {results.Count} destination(s)");

            return Task.FromResult(results);
        }

        public Task<IReadOnlyList<Flight>> SearchFlights(
            string from,
            string to,
            DateOnly departure,
            DateOnly returnDate)
        {
            Console.WriteLine(
                $"[API] SearchFlights(" +
                $"from={from}, " +
                $"to={to}, " +
                $"departure={departure}, " +
                $"returnDate={returnDate})");

            //
            // The fake dataset uses fixed example dates.
            //
            // For this training API we primarily filter by origin and
            // destination. The supplied dates are accepted so that the
            // agent has to extract them correctly from the user's request.
            //
            IReadOnlyList<Flight> results = _flights
                .Where(f =>
                    f.From.Equals(
                        from,
                        StringComparison.OrdinalIgnoreCase) &&
                    f.To.Equals(
                        to,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine(
                $"[API] -> {results.Count} flight(s)");

            return Task.FromResult(results);
        }

        public Task<IReadOnlyList<Hotel>> SearchHotels(
            string city,
            decimal maxNightlyRate)
        {
            Console.WriteLine(
                $"[API] SearchHotels(" +
                $"city={city}, " +
                $"maxNightlyRate={maxNightlyRate})");

            IReadOnlyList<Hotel> results = _hotels
                .Where(h =>
                    h.City.Equals(
                        city,
                        StringComparison.OrdinalIgnoreCase) &&
                    h.Available &&
                    h.PricePerNight <= maxNightlyRate)
                .ToList();

            Console.WriteLine(
                $"[API] -> {results.Count} hotel(s)");

            return Task.FromResult(results);
        }

        public Task<BookingResult> BookFlight(string flightId)
        {
            Console.WriteLine(
                $"[API] BookFlight(flightId={flightId})");

            var flight = _flights.FirstOrDefault(
                f => f.Id.Equals(
                    flightId,
                    StringComparison.OrdinalIgnoreCase));

            if (flight is null)
            {
                throw new ArgumentException(
                    $"Flight '{flightId}' does not exist.",
                    nameof(flightId));
            }

            var booking = CreateBooking(
                resourceId: flight.Id,
                type: BookingType.Flight,
                price: flight.Price);

            Console.WriteLine(
                $"[API] -> bookingId={booking.BookingId}, " +
                $"status={booking.Status}");

            return Task.FromResult(ToResult(booking));
        }

        public Task<BookingResult> BookHotel(string hotelId)
        {
            Console.WriteLine(
                $"[API] BookHotel(hotelId={hotelId})");

            var hotel = _hotels.FirstOrDefault(
                h => h.Id.Equals(
                    hotelId,
                    StringComparison.OrdinalIgnoreCase));

            if (hotel is null)
            {
                throw new ArgumentException(
                    $"Hotel '{hotelId}' does not exist.",
                    nameof(hotelId));
            }

            if (!hotel.Available)
            {
                throw new InvalidOperationException(
                    $"Hotel '{hotelId}' is currently unavailable.");
            }

            var booking = CreateBooking(
                resourceId: hotel.Id,
                type: BookingType.Hotel,
                price: hotel.PricePerNight);

            Console.WriteLine(
                $"[API] -> bookingId={booking.BookingId}, " +
                $"status={booking.Status}");

            return Task.FromResult(ToResult(booking));
        }

        public Task<BookingResult> GetBookingStatus(string bookingId)
        {
            Console.WriteLine(
                $"[API] GetBookingStatus(bookingId={bookingId})");

            if (!_bookings.TryGetValue(bookingId, out var booking))
            {
                throw new ArgumentException(
                    $"Booking '{bookingId}' does not exist.",
                    nameof(bookingId));
            }

            switch (_scenario)
            {
                case TravelApiScenario.HappyPath:
                    booking.Status = BookingStatus.Confirmed;
                    break;

                case TravelApiScenario.DelayedBookingConfirmation:
                    if (booking.Status == BookingStatus.Pending)
                    {
                        booking.StatusChecks++;

                        if (booking.StatusChecks >= 3)
                        {
                            booking.Status = BookingStatus.Confirmed;
                        }
                    }
                    break;

                case TravelApiScenario.FailedHotelBooking:
                    booking.Status = booking.Type switch
                    {
                        BookingType.Flight => BookingStatus.Confirmed,
                        BookingType.Hotel => BookingStatus.Failed,
                        _ => booking.Status
                    };
                    break;
            }

            Console.WriteLine(
                $"[API] -> {booking.Status} " +
                $"(status check #{booking.StatusChecks})");

            return Task.FromResult(ToResult(booking));
        }

        public Task<BookingResult> CancelBooking(string bookingId)
        {
            Console.WriteLine(
                $"[API] CancelBooking(bookingId={bookingId})");

            if (!_bookings.TryGetValue(bookingId, out var booking))
            {
                throw new ArgumentException(
                    $"Booking '{bookingId}' does not exist.",
                    nameof(bookingId));
            }

            if (booking.Status == BookingStatus.Cancelled)
            {
                Console.WriteLine(
                    "[API] -> booking already cancelled");

                return Task.FromResult(ToResult(booking));
            }

            booking.Status = BookingStatus.Cancelled;

            Console.WriteLine(
                $"[API] -> {booking.Status}");

            return Task.FromResult(ToResult(booking));
        }

        private BookingState CreateBooking(
            string resourceId,
            BookingType type,
            decimal price)
        {
            var bookingId =
                $"{(type == BookingType.Flight ? "F" : "H")}-" +
                $"{_nextBookingId++:0000}";

            var booking = new BookingState
            {
                BookingId = bookingId,
                ResourceId = resourceId,
                Type = type,
                Price = price,
                Status = BookingStatus.Pending,
                StatusChecks = 0
            };

            _bookings.Add(bookingId, booking);

            return booking;
        }

        private static BookingResult ToResult(
            BookingState booking)
        {
            return new BookingResult(
                BookingId: booking.BookingId,
                Status: booking.Status,
                Price: booking.Price);
        }

        public Hotel GetHotel(string hotelId)
        {
            foreach(Hotel hotel in _hotels)
            {
                if(hotel.Id.Equals(hotelId)) return hotel;
            }
            return null;
        }

        private enum BookingType
        {
            Flight,
            Hotel
        }

        private sealed class BookingState
        {
            public required string BookingId { get; init; }

            public required string ResourceId { get; init; }

            public required BookingType Type { get; init; }

            public required decimal Price { get; init; }

            public BookingStatus Status { get; set; }

            public int StatusChecks { get; set; }
        }
    }
}