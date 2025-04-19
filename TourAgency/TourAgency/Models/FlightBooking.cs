namespace TourAgency.Models;

public class FlightBooking
{
    public int Id { get; set; }

    public int FlightId { get; set; }
    public Flight? Flight { get; set; }

    public string TravelClass { get; set; }  // Economy, Business, etc.

    public int Passengers { get; set; }
}
