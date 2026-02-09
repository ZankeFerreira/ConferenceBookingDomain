
using System.Security.Claims;
using ConferenceBookingDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [ApiController]
    [Route("api/bookings")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private BookingManager _bookings;
        private readonly EFBookingStore _context;
        public BookingController(BookingManager manager, EFBookingStore context)
        {
            _bookings = manager;
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _context.LoadAllAsync();

            if (!bookings.Any())
            {
                return NotFound("There are no previous/current bookings");
            }

            var response = bookings.Select(r => new GetBookingsDto
            {
                room = r.Room.ID,
                startTime = r.StartTime,
                endTime = r.EndTime


            });

            return Ok(bookings);

        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employee,Receptionist")]
        public async Task<IActionResult> Book([FromBody] CreateBookingDto dto)
        {
            var room = _bookings.GetRooms().FirstOrDefault(r => r.ID == dto.roomId);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string? displayOwner = User.IsInRole("Receptionist") && !string.IsNullOrEmpty(dto.visitorName)
                                      ? dto.visitorName
                                      : User.Identity.Name;
                                      
            var request = new BookingRequest(room, dto.startTime, dto.endTime)
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





    }
}