using ConferenceBookingDomain;

public class Booking
{
    public ConferenceRoom Room { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public BookingStatus Status { get; set; }



    public Booking(BookingRequest request)
    {
        Room = request.Room;
        StartTime = request.StartTime;
        EndTime = request.EndTime;
        Status = BookingStatus.Active;

        if (request.Room == null)
        {
            throw new Exception("A room number must be entered");

        }
        if (request.StartTime >= request.EndTime)
        {
            throw new Exception("Start time must be before end time;");
        }
        if (request.StartTime < DateTime.Now)
        {
            throw new Exception("Start time must be after the current time");

        }

    }

    

    public Booking Cancel()
    {
        if (DateTime.Now >= StartTime)
        {
            throw new Exception("Cannot cancel a booking that already started/passed");
        }

        Status = BookingStatus.Cancelled;
        return this;
    }

    public bool Overlaps(DateTime start, DateTime end)
    {
        return StartTime < end && start < EndTime;
    }

    public override string ToString()
    {
        return $"{Room.RoomNumber}: {StartTime} - {EndTime} ({Status})";
    }

    
}