namespace ConferenceBookingDomain{
public class RoomNotFoundException: Exception
{
    public RoomNotFoundException(int roomId) : base($"Room with ID {roomId} was not found.")
    {
        
    }
}
}