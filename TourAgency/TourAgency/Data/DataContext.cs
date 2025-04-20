using Microsoft.EntityFrameworkCore;
using TourAgency.Models;

namespace TourAgency.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Registration of Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Flight>  Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }
        public DbSet<ActivityBooking> ActivityBookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(25);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(25);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(a =>a.Id);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(25);
                entity.Property(h => h.Location).IsRequired().HasMaxLength(255);
                entity.Property(a => a.Description).IsRequired().HasMaxLength(255);
                entity.Property(a => a.Price).IsRequired().HasPrecision(18, 2); ;
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Country).IsRequired().HasMaxLength(25);
                entity.Property(d => d.City).IsRequired().HasMaxLength(25);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.FlightNumber).IsRequired().HasMaxLength(25);
                entity.Property(f => f.Airline).IsRequired().HasMaxLength(50);
                entity.Property(f => f.Price).IsRequired().HasPrecision(18, 2); ;
            });
            
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.Name).IsRequired().HasMaxLength(50);
                entity.Property(h => h.Location).IsRequired().HasMaxLength(255);
                entity.Property(h => h.Price).IsRequired().HasPrecision(18, 2); ;
            });
            

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Url).IsRequired().HasMaxLength(255);
            });
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
            });



            //Relations
            // User-Image (Profile Image)
            modelBuilder.Entity<User>()
                .HasOne(u => u.ProfileImage)
                .WithOne()
                .HasForeignKey<User>(u => u.ProfileImageId);

            // Image relations
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Hotel)
                .WithMany(h => h.Images)
                .HasForeignKey(i => i.HotelId);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Activity)
                .WithMany(a => a.Images)
                .HasForeignKey(i => i.ActivityId);

            // Many-to-Many: Trip-Activity, Trip-Hotel, etc.
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Hotels)
                .WithMany(h => h.Trips);

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Flights)
                .WithMany(f => f.Trips);

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Destinations)
                .WithMany(d => d.Trips);

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Activities)
                .WithMany(a => a.Trips);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Trips)
                .WithMany(t => t.Reservations);


            // Booking → BookingItems (1-to-many)
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Items)
                .WithOne()
                .HasForeignKey(i => i.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // BookingItem → HotelBooking (optional FK by ID only, not navigation property)
            modelBuilder.Entity<BookingItem>()
                .Property(b => b.Type)
                .IsRequired()
                .HasMaxLength(20);

            // HotelBooking relation (HotelBooking → Hotel)
            modelBuilder.Entity<HotelBooking>()
                .HasOne(hb => hb.Hotel)
                .WithMany()
                .HasForeignKey(hb => hb.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // FlightBooking
            modelBuilder.Entity<FlightBooking>().HasKey(fb => fb.Id);

            modelBuilder.Entity<FlightBooking>()
                .HasOne(fb => fb.Flight)
                .WithMany()
                .HasForeignKey(fb => fb.FlightId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActivityBooking>()
                .HasOne(ab => ab.Activity)
                .WithMany()
                .HasForeignKey(ab => ab.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            //SeedData
            SeedData.Seed(modelBuilder);
        }
        public DbSet<TourAgency.Models.Destination> Destination { get; set; } = default!;

            
    }
}
