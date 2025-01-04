namespace TourAgency.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; } = String.Empty;
        public string Airline { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public ICollection<Trip>? Trips { get; set; }
    }

}
