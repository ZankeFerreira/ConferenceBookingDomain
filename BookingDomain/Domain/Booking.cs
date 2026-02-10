using ConferenceBookingDomain;

namespace ConferenceBookingDomain{
public class Booking
{
    public int Id { get; set;}
    public ConferenceRoom Room { get; set;}
    public string CreatedBy{get; set;}
    public string BookingFor{get;set;}
    public int Capacity{get; set;}
    public DateTime StartTime { get; set;}
    public DateTime EndTime { get;set; }
    public BookingStatus Status { get; set; }
    public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
    public DateTime ? CancelledAt { get; set;} = DateTime.UtcNow;



    public Booking (ConferenceRoom room, DateTime start, DateTime end, int capacity){
        
        if (capacity <= 0) throw new ArgumentException("Capacity must be positive.");

        Room = room;    //Validation in conference room
        Capacity = capacity;
        StartTime = start;
        EndTime = end;
        CreatedAt = DateTime.UtcNow;
        Status = BookingStatus.Pending;
        CancelledAt = DateTime.UtcNow;
    }


    private Booking() { }
    
    public void Confirm()
        {
            Status = BookingStatus.Confirmed;
        }
    public Booking Cancel()
    {
        Status = BookingStatus.Cancelled;
        return this;
    }
}
}