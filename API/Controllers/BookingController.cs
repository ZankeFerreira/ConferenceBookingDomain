
using System.Security.Claims;
using ConferenceBookingDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookingDomain.Persistence;
using Microsoft.EntityFrameworkCore;


namespace API.controllers
{
    [ApiController]
    [Route("api/bookings")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private BookingManager _bookings;
        private readonly EFBookingStore _context;
        private readonly BookingDbContext _db;
        public BookingController(BookingManager manager, EFBookingStore context, BookingDbContext db)
        {
            _bookings = manager;
            _context = context;
            _db = db;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllBookings()
        {

            var bookings = await _context.LoadAsync();

            if (!bookings.Any())
            {
                return NotFound("There are no previous/current bookings");
            }

            var response = bookings.Select(r => new SummarisedBookingDto

            {
                id = r.Room.Id,
                startTime = r.StartTime,
                endTime = r.EndTime,
                capacity = r.Capacity
            });

            return Ok(bookings);
        }



        [HttpPost]
        [Authorize(Roles = "Admin,Employee,Receptionist")]
        public async Task<IActionResult> Book([FromBody] CreateBookingDto dto)
        {

            var room = await _db.ConferenceRooms.FindAsync(dto.roomId);
            if (room == null)
            {
                return NotFound(new { error = "RoomNotFound", detail = $"Room with ID {dto.roomId} does not exist." });
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string? displayOwner = User.IsInRole("Receptionist") && !string.IsNullOrEmpty(dto.visitorName)
                                      ? dto.visitorName
                                      : User.Identity.Name;

            var request = new BookingRequest(room, dto.startTime, dto.endTime, dto.capacity)
            {
                UserId = userId,
                VisitorName = displayOwner
            };
            var output = await _bookings.CreateBooking(request);

            return Ok(output);
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isAdmin = User.IsInRole("Admin");

            await _bookings.DeleteBooking(id, userId, isAdmin);

            return Ok("Booking successfully deleted");

        }

        [HttpGet("location")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBookingsLocation([FromQuery] string location)
        {
            
            var query = _db.Booking.AsQueryable();

            query = query.Include(r => r.Room).Where(r => r.Room.Location == location);

            int page = 1;
            int pageSize = 10;
            var total = await query.CountAsync();

            if (!query.Any())
            {
                return NotFound("No bookings found for location: {location}");
            }

            var response = await query
            .AsNoTracking().
            OrderByDescending(r => r.Room.Location)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new SummarisedBookingDto
            {
                id = r.Id,
                location = r.Room.Location,
                room = r.Room.RoomID,
                startTime = r.StartTime,
                endTime = r.EndTime,
                capacity = r.Capacity
            }).ToListAsync();

            return Ok(new { total, response });
        }

        [HttpGet("rooms")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBookingsRooms([FromQuery] string room)
        {
            var query = _db.Booking.AsQueryable();

            query = query.Include(r => r.Room).Where(r => r.Room.RoomID == room);

            int page = 1;
            int pageSize = 10;
            var total = await query.CountAsync();

            if (!query.Any())
            {
                return NotFound("No bookings found for location: {location}");
            }

            var response = await query
            .AsNoTracking().
            OrderByDescending(r => r.Room.RoomID)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new SummarisedBookingDto
            {
                id = r.Id,
                location = r.Room.Location,
                room = r.Room.RoomID,
                startTime = r.StartTime,
                endTime = r.EndTime,
                capacity = r.Capacity
            }).ToListAsync();

            return Ok(new { total, response });
        }

        [HttpGet("dates")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBookingsByDates([FromQuery] DateTime Start, [FromQuery] DateTime End)
        {
            var query = _db.Booking.AsQueryable();

            query = query.Where(r => r.StartTime < End && r.EndTime > Start);

            int page = 1;
            int pageSize = 10;
            var total = await query.CountAsync();
            var response = await query
            .AsNoTracking().
            OrderBy(r => r.StartTime)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new SummarisedBookingDto
            {
                id = r.Id,
                location = r.Room.Location,
                room = r.Room.RoomID,
                startTime = r.StartTime,
                endTime = r.EndTime,
                capacity = r.Capacity
            }).ToListAsync();

            return Ok(new { total, response });

        }
        [HttpGet("status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBookingsByStatus([FromQuery] RoomStatus status)
        {
            var query = _db.Booking.AsQueryable();

            query = query.Where(r => r.Room.Status == status);

            int page = 1;
            int pageSize = 10;
            var total = await query.CountAsync();
            
            var response = await query
            .AsNoTracking().
            OrderByDescending(r => r.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new
            {
                id = r.Id,
                location = r.Room.Location,
                room = r.Room.RoomID,
                status = r.Room.Status,
                startTime = r.StartTime,
                endTime = r.EndTime,
                capacity = r.Capacity
            }).ToListAsync();

            return Ok(new { total, response });

        }
    }
}