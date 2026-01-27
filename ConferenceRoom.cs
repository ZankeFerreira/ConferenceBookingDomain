public class ConferenceRoom
{
    public string RoomNumber { get;  }

    public int Capacity { get; }

    public RoomStatus Status { get; set; }

    public ConferenceRoom(string roomNumber, int capacity)
    {
        if (string.IsNullOrWhiteSpace(roomNumber))
        {
            throw new Exception("A room number must be entered");
        }
        if (capacity < 10 || capacity > 20)
        {
            throw new Exception("Capacity must be between 10 and 20");
            //Assuming there are rooms with a min of 10 and the max of 20
        }

        RoomNumber = roomNumber;
        Capacity = capacity;
        Status = RoomStatus.Available;
    }

    public void UnderMaintenance()
    {
        Status = RoomStatus.UnderMaintenance;
    }

    public void Unavailable()
    {
        Status = RoomStatus.Unavailable;
    }

    public void Available()
    {
        Status = RoomStatus.Available;
    }









}
