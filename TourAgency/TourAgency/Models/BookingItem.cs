namespace TourAgency.Models;

public class BookingItem
{
    public int Id { get; set; }

    public int BookingId { get; set; }
    public string Type { get; set; }  // "Hotel", etc.
    public int EntityBookingId { get; set; }  // HotelBooking.Id, etc.
}
