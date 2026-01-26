class Booking
{
    public ConferenceRoom Room{get; set;}
    public DateTime StartTime{get; set;}
    public DateTime EndTime {get; set;}
    public BookingStatus Status {get; set;}

    public Booking (ConferenceRoom room, DateTime startTime, DateTime endTime)
    {
        Room = room;
        StartTime = startTime;
        EndTime = endTime;
        Status = BookingStatus.Active;

        if (room == null)
        {
            throw new Exception ("A room number must be entered");

        }
        if (startTime >= endTime)
        {
            throw new Exception("Start time must be before end time;");
        }
        if (StartTime > DateTime.Now )
        {
            throw new Exception("Start time must be after the current time");

        }
        
    }

    public void Cancel()
    {
        if (DateTime.Now >= StartTime)
        {
            throw new Exception("Cannot cancel a booking that already started/passed");
        }
    }
}