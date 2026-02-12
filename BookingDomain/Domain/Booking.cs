using ConferenceBookingDomain.Domain;

namespace ConferenceBookingDomain{
public class Booking
{
    public int Id { get; set;}
    public ConferenceRoom Room { get; set;}
    public int RoomId {get;set;}
    public ApplicationUser User { get; set;}
    public string UserId { get; set; }
    public string CreatedBy{get; set;}
    public string BookingFor{get;set;}
    public int Capacity{get; set;}
    public DateTime StartTime { get; set;}
    public DateTime EndTime { get;set; }
    public BookingStatus Status { get; set; }
    public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
    public DateTime ? CancelledAt { get; set;}

    
    
    public void Confirm()
        {
            Status = BookingStatus.Confirmed;
        }
    public Booking Cancel()
    {
        Status = BookingStatus.Cancelled;
        CancelledAt = DateTime.UtcNow;
        return this;
    }
}
}