using System;

namespace TourAgency.Models
{
    public class BookingRequest
    {
        public string UserEmail { get; set; }
        public DateTime BookingDate { get; set; }

        // Partie spécifique à la réservation d'hôtel
        public HotelBooking? HotelBooking { get; set; }

        // 🔜 Tu pourras facilement ajouter d'autres types comme :
        public FlightBooking? FlightBooking { get; set; }
        public List<ActivityBooking>? ActivityBookings { get; set; }
    }
}
