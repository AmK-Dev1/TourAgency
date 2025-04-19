namespace TourAgency.Models;

public class ActivityBooking
{
    public int Id { get; set; }

    public int ActivityId { get; set; }
    public Activity? Activity { get; set; }

    public DateTime ActivityDate { get; set; }
    public int Participants { get; set; }
}