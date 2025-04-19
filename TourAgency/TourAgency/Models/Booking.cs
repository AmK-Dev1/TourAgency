namespace TourAgency.Models;

public class Booking
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    public List<BookingItem> Items { get; set; }
}
