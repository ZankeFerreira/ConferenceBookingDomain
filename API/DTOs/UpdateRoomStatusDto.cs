using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using ConferenceBookingDomain;

public class UpdateRoomStatusDto{
    [Required]
    public RoomStatus status {get; set;}
}