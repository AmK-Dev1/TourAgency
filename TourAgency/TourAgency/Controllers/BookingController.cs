using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourAgency.Data;
using TourAgency.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TourAgency.Services;

namespace TourAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly MailerService _mailerService;

        public BookingController(DataContext context, MailerService mailer)
        {
            _context = context;
            _mailerService = mailer;
        }

        // GET: api/booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings
                .Include(b => b.Items)
                .ToListAsync();
        }

        // GET: api/booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null)
                return NotFound();

            return booking;
        }

        // POST: api/booking
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking([FromBody] BookingRequest request)
        {
            var bookingItems = new List<BookingItem>();

            if (request.HotelBooking != null)
            {
                _context.HotelBookings.Add(request.HotelBooking);
                await _context.SaveChangesAsync();

                bookingItems.Add(new BookingItem
                {
                    Type = "Hotel",
                    EntityBookingId = request.HotelBooking.Id
                });
            }

            if (request.FlightBooking != null)
            {
                _context.FlightBookings.Add(request.FlightBooking);
                await _context.SaveChangesAsync();

                bookingItems.Add(new BookingItem
                {
                    Type = "Flight",
                    EntityBookingId = request.FlightBooking.Id
                });
            }

            if (request.ActivityBookings != null && request.ActivityBookings.Any())
            {
                foreach (var activityBooking in request.ActivityBookings)
                {
                    _context.ActivityBookings.Add(activityBooking);
                    await _context.SaveChangesAsync();

                    bookingItems.Add(new BookingItem
                    {
                        Type = "Activity",
                        EntityBookingId = activityBooking.Id
                    });
                }
            }

            if (!bookingItems.Any())
                return BadRequest("No booking items provided.");

            var booking = new Booking
            {
                UserEmail = request.UserEmail,
                BookingDate = request.BookingDate,
                Items = bookingItems
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            _mailerService.SendBookingConfirmation(request.UserEmail, booking);

            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }
    }
}