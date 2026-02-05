

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

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] CreateBookingDto dto)
        {
            


                var room = _bookings.GetRooms().FirstOrDefault(r => r.ID == dto.roomId);
                
                var request = new BookingRequest(room, dto.startTime, dto.endTime);
                var output = await _bookings.CreateBooking(request);

                if (output == null)
                {
                    return BadRequest("Invalid input");
                }

                return Ok(output);

           
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            
                await _bookings.DeleteBooking(id);
                

                return Ok("Booking successfully deleted");
           
        }





    }
}