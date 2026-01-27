using ConferenceBookingDomain;

class Booking
{
    public ConferenceRoom Room{get; }
    public DateTime StartTime{get; }
    public DateTime EndTime {get; }
    public BookingStatus Status {get; set;}

  
    
    public Booking (BookingRequest request)
    {
        Room = request.room;
        StartTime = request.startTime;
        EndTime = request.endTime;
        Status = BookingStatus.Active;

        if (request.room == null)
        {
            throw new Exception ("A room number must be entered");

        }
        if (request.startTime >= request.endTime)
        {
            throw new Exception("Start time must be before end time;");
        }
        if (request.startTime < DateTime.Now )
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
}