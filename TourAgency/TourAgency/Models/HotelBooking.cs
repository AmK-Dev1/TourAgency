namespace TourAgency.Models
{
    public class HotelBooking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string RoomType { get; set; }
        public int Guests { get; set; }
    }
}
