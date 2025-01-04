namespace TourAgency.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Country { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string? ImageUrl { get; set; }

        public ICollection<Trip>? Trips { get; set; }
    }

}
