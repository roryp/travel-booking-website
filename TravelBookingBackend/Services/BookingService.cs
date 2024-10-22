using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelBookingBackend.Services
{
    public class BookingService
    {
        private readonly List<Booking> bookings;

        public BookingService()
        {
            bookings = new List<Booking>
            {
                new Booking { CustomerName = "John Doe", BookingDate = new DateTime(2023, 5, 1) },
                new Booking { CustomerName = "Jane Smith", BookingDate = new DateTime(2023, 6, 15) },
                new Booking { CustomerName = "Alice Johnson", BookingDate = new DateTime(2023, 7, 20) }
            };
        }

        public Task<List<string>> SearchBookings(string customerName, DateTime bookingDate)
        {
            var results = new List<string>();

            foreach (var booking in bookings)
            {
                if (booking.CustomerName.Contains(customerName, StringComparison.OrdinalIgnoreCase) &&
                    booking.BookingDate.Date == bookingDate.Date)
                {
                    results.Add($"Booking for {booking.CustomerName} on {booking.BookingDate.ToShortDateString()}");
                }
            }

            return Task.FromResult(results);
        }

        private class Booking
        {
            public string CustomerName { get; set; }
            public DateTime BookingDate { get; set; }
        }
    }
}
