namespace TourAgency.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Trip>? Trips { get; set; }
        public DateTime ReservationDate { get; set; }
    }

}
