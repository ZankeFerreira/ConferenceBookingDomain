

using ConferenceBookingDomain;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController:ControllerBase
    {
        private BookingManager _bookings;
        public BookingController (BookingManager manager)
        {
            _bookings = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = _bookings.GetBookings();

            if (!bookings.Any())
            {
                return NotFound("There are no previous/current bookings");
            }

            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] BookingRequest request)
        {
            var output = await _bookings.CreateBooking(request);

            if (output == null)
            {
                return BadRequest("Invalid input");
            }
          
            return Ok(output);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            bool deleted = await _bookings.DeleteBooking(id);
            if (!deleted)
            {
                return NotFound($"Booking with ID {id} not found.");
            }

            return NoContent();
        }

        


        
    }
}