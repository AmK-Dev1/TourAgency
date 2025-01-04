using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TourAgency.Migrations
{
    /// <inheritdoc />
    public partial class images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTrip",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "int", nullable: false),
                    TripsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTrip", x => new { x.ActivitiesId, x.TripsId });
                    table.ForeignKey(
                        name: "FK_ActivityTrip_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityTrip_Trips_TripsId",
                        column: x => x.TripsId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinationTrip",
                columns: table => new
                {
                    DestinationsId = table.Column<int>(type: "int", nullable: false),
                    TripsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationTrip", x => new { x.DestinationsId, x.TripsId });
                    table.ForeignKey(
                        name: "FK_DestinationTrip_Destination_DestinationsId",
                        column: x => x.DestinationsId,
                        principalTable: "Destination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationTrip_Trips_TripsId",
                        column: x => x.TripsId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightTrip",
                columns: table => new
                {
                    FlightsId = table.Column<int>(type: "int", nullable: false),
                    TripsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightTrip", x => new { x.FlightsId, x.TripsId });
                    table.ForeignKey(
                        name: "FK_FlightTrip_Flights_FlightsId",
                        column: x => x.FlightsId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightTrip_Trips_TripsId",
                        column: x => x.TripsId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelTrip",
                columns: table => new
                {
                    HotelsId = table.Column<int>(type: "int", nullable: false),
                    TripsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelTrip", x => new { x.HotelsId, x.TripsId });
                    table.ForeignKey(
                        name: "FK_HotelTrip_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelTrip_Trips_TripsId",
                        column: x => x.TripsId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProfileImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Images_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTrip",
                columns: table => new
                {
                    ReservationsId = table.Column<int>(type: "int", nullable: false),
                    TripsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTrip", x => new { x.ReservationsId, x.TripsId });
                    table.ForeignKey(
                        name: "FK_ReservationTrip_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationTrip_Trips_TripsId",
                        column: x => x.TripsId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A thrilling ski trip in the Alps.", "Skiing Adventure", 150m },
                    { 2, "Explore the wonders of the local museum.", "Museum Tour", 50m },
                    { 3, "A guided tour of the city's landmarks.", "City Sightseeing", 75m },
                    { 4, "A challenging hike through scenic mountains.", "Mountain Hiking", 100m },
                    { 5, "Experience underwater adventure.", "Scuba Diving", 200m }
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "Id", "City", "Country", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "Paris", "France", "images/france.jpg" },
                    { 2, "Rome", "Italy", "images/rome.jpg" },
                    { 3, "New York", "USA", "images/usa.jpg" },
                    { 4, "Tokyo", "Japan", "images/japan.jpg" },
                    { 5, "Sydney", "Australia", "images/australia.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Airline", "ArrivalTime", "DepartureTime", "FlightNumber", "Price" },
                values: new object[,]
                {
                    { 1, "Air France", new DateTime(2025, 1, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "AF123", 500m },
                    { 2, "Delta Airlines", new DateTime(2025, 1, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), "DL456", 450m },
                    { 3, "British Airways", new DateTime(2025, 1, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 7, 30, 0, 0, DateTimeKind.Unspecified), "BA789", 550m },
                    { 4, "Lufthansa", new DateTime(2025, 1, 18, 15, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 18, 9, 15, 0, 0, DateTimeKind.Unspecified), "LH321", 600m },
                    { 5, "Qantas", new DateTime(2025, 1, 20, 14, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 6, 45, 0, 0, DateTimeKind.Unspecified), "QF654", 650m }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "ImageUrl", "Location", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, "Paris", "Grand Paris Hotel", 150m },
                    { 2, null, "Rome", "Rome Luxury Suites", 200m },
                    { 3, null, "New York", "NYC Central Park Hotel", 180m },
                    { 4, null, "Tokyo", "Tokyo Sakura Hotel", 140m },
                    { 5, null, "Sydney", "Sydney Harbour Hotel", 220m }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ActivityId", "HotelId", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, "https://example.com/images/profile1.jpg", null },
                    { 2, null, null, "https://example.com/images/profile2.jpg", null },
                    { 3, null, null, "https://example.com/images/profile3.jpg", null },
                    { 4, null, null, "https://example.com/images/profile4.jpg", null },
                    { 5, null, null, "https://example.com/images/profile5.jpg", null },
                    { 6, null, null, "images/france", null },
                    { 7, null, null, "images/japan", null },
                    { 8, null, null, "images/rome", null },
                    { 9, null, null, "images/usa", null }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "European Adventure" },
                    { 2, "American Journey" },
                    { 3, "Asian Escape" },
                    { 4, "Oceanic Retreat" },
                    { 5, "Cultural Tour" }
                });

            migrationBuilder.InsertData(
                table: "ActivityTrip",
                columns: new[] { "ActivitiesId", "TripsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "DestinationTrip",
                columns: new[] { "DestinationsId", "TripsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "FlightTrip",
                columns: new[] { "FlightsId", "TripsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "HotelTrip",
                columns: new[] { "HotelsId", "TripsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "ProfileImageId" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", "password123", 1 },
                    { 2, "jane.smith@example.com", "Jane Smith", "password456", 2 },
                    { 3, "alice.johnson@example.com", "Alice Johnson", "password789", 3 },
                    { 4, "bob.williams@example.com", "Bob Williams", "password111", 4 },
                    { 5, "emma.davis@example.com", "Emma Davis", "password222", 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "ReservationDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTrip_TripsId",
                table: "ActivityTrip",
                column: "TripsId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationTrip_TripsId",
                table: "DestinationTrip",
                column: "TripsId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTrip_TripsId",
                table: "FlightTrip",
                column: "TripsId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelTrip_TripsId",
                table: "HotelTrip",
                column: "TripsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ActivityId",
                table: "Images",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HotelId",
                table: "Images",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTrip_TripsId",
                table: "ReservationTrip",
                column: "TripsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileImageId",
                table: "Users",
                column: "ProfileImageId",
                unique: true,
                filter: "[ProfileImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Activities_ActivityId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Hotels_HotelId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "ActivityTrip");

            migrationBuilder.DropTable(
                name: "DestinationTrip");

            migrationBuilder.DropTable(
                name: "FlightTrip");

            migrationBuilder.DropTable(
                name: "HotelTrip");

            migrationBuilder.DropTable(
                name: "ReservationTrip");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
