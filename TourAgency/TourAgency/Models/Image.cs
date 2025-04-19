
namespace TourAgency.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; } = String.Empty;
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public int? ActivityId { get; set; }
        public Activity? Activity { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }

}
