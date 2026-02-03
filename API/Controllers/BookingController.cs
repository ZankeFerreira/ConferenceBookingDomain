

using ConferenceBookingDomain;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController:ControllerBase
    {
        private readonly BookingManager _bookings;
        public BookingController (BookingManager manager)
        {
            _bookings = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = _bookings.GetBookings();

            if (!bookings.Any())
            {
                return NotFound("There are no previous/current bookings");
            }

            return Ok(bookings);
        }
    }
}