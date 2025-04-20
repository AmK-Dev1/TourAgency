namespace TourAgency.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty ;
        public decimal Price { get; set; }



        public string? ImageUrl { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<Trip>? Trips { get; set; }
    }

}
