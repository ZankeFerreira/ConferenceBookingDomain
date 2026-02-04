

using ConferenceBookingDomain;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private BookingManager _bookings;
        public BookingController(BookingManager manager)
        {
            _bookings = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var bookings = _bookings.GetBookings();

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
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] CreateBookingDto dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {


                var room = _bookings.GetRooms().FirstOrDefault(r => r.ID == dto.roomId);
                if (room == null)
                {
                    return NotFound($"Room with ID {dto.roomId} does not exist.");
                }
                var request = new BookingRequest(room, dto.startTime, dto.endTime);
                var output = await _bookings.CreateBooking(request);

                if (output == null)
                {
                    return BadRequest("Invalid input");
                }

                return Ok(output);

            }
            catch (BookingConflictException ex)
            {
                // 422 is used for business/domain rule violations (like overlaps)
                return UnprocessableEntity(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // 400 for logic errors (e.g. EndTime before StartTime)
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the booking."); // 500
            }

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            try
            {
                bool deleted = await _bookings.DeleteBooking(id);
                if (!deleted)
                {
                    return NotFound($"Booking with ID {id} not found.");
                }

                return Ok("Booking successfully deleted");
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to delete booking."); // 500
            }
        }





    }
}