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

                var response = rooms.Select(r => new GetRoomsDto
                {
                    ID = r.ID,
                    RoomNumber = r.RoomNumber,
                    Capacity = r.Capacity,
                    Status = r.Status,



                });

                return Ok(response);
           

        }

        [HttpPatch("{id}/status")]
        public IActionResult UpdateRoomStatus(int id, [FromBody] UpdateRoomStatusDto dto)
        {
             
                _rooms.UpdateRoomStatus(id, dto.status);

               

                return Ok("Room status changed"); // 204 Success, no content to return
            
        }




    }
}