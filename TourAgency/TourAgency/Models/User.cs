namespace TourAgency.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public int? ProfileImageId { get; set; }
        public Image? ProfileImage { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }

}
