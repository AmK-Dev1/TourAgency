﻿using Microsoft.EntityFrameworkCore;
using TourAgency.Models;

namespace TourAgency.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Images
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Url = "https://example.com/images/profile1.jpg" },
                new Image { Id = 2, Url = "https://example.com/images/profile2.jpg" },
                new Image { Id = 3, Url = "https://example.com/images/profile3.jpg" },
                new Image { Id = 4, Url = "https://example.com/images/profile4.jpg" },
                new Image { Id = 5, Url = "https://example.com/images/profile5.jpg" },

                new Image { Id = 6, Url = "images/france" },
                new Image { Id = 7, Url = "images/japan" },
                new Image { Id = 8, Url = "images/rome" },
                new Image { Id = 9, Url = "images/usa" }
             

            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "password123", ProfileImageId = 1 },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password456", ProfileImageId = 2 },
                new User { Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com", Password = "password789", ProfileImageId = 3 },
                new User { Id = 4, Name = "Bob Williams", Email = "bob.williams@example.com", Password = "password111", ProfileImageId = 4 },
                new User { Id = 5, Name = "Emma Davis", Email = "emma.davis@example.com", Password = "password222", ProfileImageId = 5 }
            );

            // Seed Activities
            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, Name = "Visit the Eiffel Tower", Description = "Visit the Eiffel Tower and enjoy a dinner cruise on the Seine.", Location= "Paris", Price = 150, ImageUrl= "images/actPa.jpg" },
                new Activity { Id = 2, Name = "The Empire State Building", Description = "Climb the Empire State Building or Top of the Rock for amazing views.", Location= "New York", Price = 150, ImageUrl= "images/actNy.jpg" },
                new Activity { Id = 3, Name = "Visit Shibuya", Description = "Visit Shibuya and cross the world-famous scramble crossing", Location = "Tokyo", Price = 150, ImageUrl= "images/actTo.jpg" },
                new Activity { Id = 4, Name = "The Colosseum", Description = "Explore the Colosseum and the Roman Forum toss a coin into the Trevi Fountain for good luck.", Location= "Rome", Price = 200, ImageUrl= "images/actRo.jpg" },
                new Activity { Id = 5, Name = "Sydney Opera House", Description = "Admire the iconic Sydney Opera House and Harbour Bridge Relax at Bondi Beach and walk the scenic Bondi to Coogee coastal trail.", Location= "Sydney", Price = 150, ImageUrl= "images/actSy.jpg" },
                new Activity { Id = 6, Name = "The historic Casbah", Description = "Wander through the historic Casbah of Algiers, a UNESCO World Heritage site", Location = "Algiers", Price = 100, ImageUrl= "images/actAl.jpg" },
                new Activity { Id = 7, Name = "Palace of the Parliament", Description = "Visit the massive Palace of the Parliament, one of the largest buildings in the world", Location = "Bucharest", Price = 175, ImageUrl= "images/actBu.jpg" }
            );

            // Seed Destinations
            modelBuilder.Entity<Destination>().HasData(
                new Destination { Id = 1, Country = "France", City = "Paris", ImageUrl="images/france.jpg"  },
                new Destination { Id = 2, Country = "USA", City = "New York", ImageUrl = "images/usa.jpg" },
                new Destination { Id = 3, Country = "Japan", City = "Tokyo", ImageUrl = "images/japan.jpg" },
                new Destination { Id = 4, Country = "Italy", City = "Rome", ImageUrl = "images/rome.jpg" },
                new Destination { Id = 5, Country = "Australia", City = "Sydney", ImageUrl = "images/australia.jpg" },
                new Destination { Id = 6, Country = "Algeria", City = "Algiers", ImageUrl = "images/australia.jpg" },
                new Destination { Id = 7, Country = "Romania", City = "Bucharest", ImageUrl = "images/australia.jpg" }

            );

            // Seed Flights
            modelBuilder.Entity<Flight>().HasData(
                new Flight { Id = 1, FlightNumber = "AF123", Airline = "Air France", Price = 500, DepartureTime = new DateTime(2025, 1, 10, 8, 0, 0), ArrivalTime = new DateTime(2025, 1, 10, 14, 0, 0) },
                new Flight { Id = 2, FlightNumber = "DL456", Airline = "Delta Airlines", Price = 450, DepartureTime = new DateTime(2025, 1, 12, 10, 0, 0), ArrivalTime = new DateTime(2025, 1, 12, 16, 0, 0) },
                new Flight { Id = 3, FlightNumber = "BA789", Airline = "British Airways", Price = 550, DepartureTime = new DateTime(2025, 1, 15, 7, 30, 0), ArrivalTime = new DateTime(2025, 1, 15, 13, 30, 0) },
                new Flight { Id = 4, FlightNumber = "LH321", Airline = "Lufthansa", Price = 600, DepartureTime = new DateTime(2025, 1, 18, 9, 15, 0), ArrivalTime = new DateTime(2025, 1, 18, 15, 45, 0) },
                new Flight { Id = 5, FlightNumber = "QF654", Airline = "Qantas", Price = 650, DepartureTime = new DateTime(2025, 1, 20, 6, 45, 0), ArrivalTime = new DateTime(2025, 1, 20, 14, 45, 0) }
            );

            // Seed Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hôtel du Louvre by Hyatt", Location = "Paris", Price = 150 , ImageUrl="images/hotelPa.jpg" },
                new Hotel { Id = 2, Name = "Hôtel Quin Central Park", Location = "New York", Price = 200, ImageUrl = "images/hotelNy.jpg" },
                new Hotel { Id = 3, Name = "Hôtel Park Hyatt", Location = "Tokyo", Price = 180, ImageUrl = "images/hotelTo.jpg" },
                new Hotel { Id = 4, Name = "Hôtel de Russie", Location = "Rome", Price = 140, ImageUrl = "images/hotelRo.jpg" },
                new Hotel { Id = 5, Name = "Hôtel Shangri-La", Location = "Sydney", Price = 200, ImageUrl = "images/hotelSy.jpg" },
                new Hotel { Id = 6, Name = "Hôtel El Aurassi", Location = "Algiers", Price = 280, ImageUrl = "images/hotelAl.jpg" },
                new Hotel { Id = 7, Name = "Hôtel Le Scala Boutique", Location = "Bucharest", Price = 190, ImageUrl = "images/hotelBu.jpg" }
            );

            // Seed Trips
            modelBuilder.Entity<Trip>().HasData(
                new Trip { Id = 1, Name = "European Adventure" },
                new Trip { Id = 2, Name = "American Journey" },
                new Trip { Id = 3, Name = "Asian Escape" },
                new Trip { Id = 4, Name = "Oceanic Retreat" },
                new Trip { Id = 5, Name = "Cultural Tour" }
            );

            // Seed Reservations
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, UserId = 1, ReservationDate = new DateTime(2025, 1, 1) },
                new Reservation { Id = 2, UserId = 2, ReservationDate = new DateTime(2025, 1, 2) },
                new Reservation { Id = 3, UserId = 3, ReservationDate = new DateTime(2025, 1, 3) },
                new Reservation { Id = 4, UserId = 4, ReservationDate = new DateTime(2025, 1, 4) },
                new Reservation { Id = 5, UserId = 5, ReservationDate = new DateTime(2025, 1, 5) }
            );

            // Seed Relationships: HotelTrip
            modelBuilder.Entity("HotelTrip").HasData(
                new { HotelsId = 1, TripsId = 1 },
                new { HotelsId = 2, TripsId = 1 },
                new { HotelsId = 3, TripsId = 2 },
                new { HotelsId = 4, TripsId = 3 },
                new { HotelsId = 5, TripsId = 4 }
            );

            // Seed Relationships: FlightTrip
            modelBuilder.Entity("FlightTrip").HasData(
                new { FlightsId = 1, TripsId = 1 },
                new { FlightsId = 2, TripsId = 2 },
                new { FlightsId = 3, TripsId = 3 },
                new { FlightsId = 4, TripsId = 4 },
                new { FlightsId = 5, TripsId = 5 }
            );

            // Seed Relationships: DestinationTrip
            modelBuilder.Entity("DestinationTrip").HasData(
                new { DestinationsId = 1, TripsId = 1 },
                new { DestinationsId = 2, TripsId = 1 },
                new { DestinationsId = 3, TripsId = 2 },
                new { DestinationsId = 4, TripsId = 3 },
                new { DestinationsId = 5, TripsId = 4 }
            );

            // Seed Relationships: ActivityTrip
            modelBuilder.Entity("ActivityTrip").HasData(
                new { ActivitiesId = 1, TripsId = 1 },
                new { ActivitiesId = 2, TripsId = 2 },
                new { ActivitiesId = 3, TripsId = 3 },
                new { ActivitiesId = 4, TripsId = 4 },
                new { ActivitiesId = 5, TripsId = 5 }
            );

            // Seed hotel reservation : 
            modelBuilder.Entity<HotelBooking>().HasData(
                new HotelBooking
                {
                    Id = 1,
                    HotelId = 1, // Grand Paris Hotel
                    CheckIn = new DateTime(2025, 6, 10),
                    CheckOut = new DateTime(2025, 6, 15),
                    RoomType = "Double",
                    Guests = 2
                }
            );

            // Seed booking
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    UserEmail = "john.doe@example.com",
                    BookingDate = new DateTime(2025, 6, 1)
                }
            );

            //Seed booking Item : 
            modelBuilder.Entity<BookingItem>().HasData(
                new BookingItem
                {
                    Id = 1,
                    BookingId = 1,
                    Type = "Hotel",
                    EntityBookingId = 1 // correspond à HotelBooking.Id
                }
            );

        }
    }
}
