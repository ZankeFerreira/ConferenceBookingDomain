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
            var rooms = _rooms.GetRooms();

            if (!rooms.Any())
            {
                return NotFound("There are no rooms available");
            }

            return Ok(rooms);
        }

        [HttpPatch("{id}/status")]
        public IActionResult UpdateRoomStatus(int id, [FromBody] RoomStatus newStatus)
        {
            var success = _rooms.UpdateRoomStatus(id, newStatus);

            if (!success)
            {
                return NotFound($"Room with ID {id} not found.");
            }

            return Ok("Room status changed"); // 204 Success, no content to return
        }




    }
}