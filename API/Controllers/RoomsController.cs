using ConferenceBookingDomain;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private BookingManager _rooms;

        public RoomsController(BookingManager manager)
        {
            _rooms = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                var rooms = _rooms.GetRooms();

                if (!rooms.Any())
                {
                    return NotFound("There are no rooms available");
                }

                var response = rooms.Select(r => new GetRoomsDto
                {
                    ID = r.ID,
                    RoomNumber = r.RoomNumber,
                    Capacity = r.Capacity,
                    Status = r.Status,



                });

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error."); // 500
            }

        }

        [HttpPatch("{id}/status")]
        public IActionResult UpdateRoomStatus(int id, [FromBody] UpdateRoomStatusDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Invalid status");
                }
                var success = _rooms.UpdateRoomStatus(id, dto.status);

                if (!success)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                return Ok("Room status changed"); // 204 Success, no content to return
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error."); // 500
            }
        }




    }
}