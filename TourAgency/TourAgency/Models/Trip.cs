namespace TourAgency.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<Hotel>? Hotels { get; set; }
        public ICollection<Flight>? Flights { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
        public ICollection<Activity>? Activities { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }

}
