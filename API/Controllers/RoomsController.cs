using ConferenceBookingDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

            var rooms = await _rooms.GetRooms();

            if (!rooms.Any())
            {
                return NotFound("There are no rooms available");
            }

            var response = rooms.Select(r => new GetRoomsDto
            {
                ID = r.Id,
                RoomID = r.RoomID,
                Location = r.Location,
                Capacity = r.Capacity,
                Status = r.Status,



            });
            return Ok(response);
        }

        
        [HttpPatch("{id}/status")]
        //[Authorize(Roles ="Facilities_Manager")]
        public IActionResult UpdateRoomStatus(int id, [FromBody] UpdateRoomStatusDto dto)
        {

            _rooms.UpdateRoomStatus(id, dto.status);
            return Ok("Room status changed");
        }
    }
}