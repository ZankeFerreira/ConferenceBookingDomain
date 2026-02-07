

namespace ConferenceBookingDomain
{

    public record BookingRequest
    {
        public string? UserId{get;set;}
        public string? VisitorName{get;set;}
        public ConferenceRoom Room { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }


        public BookingRequest(
            ConferenceRoom room,
            DateTime startTime,
            DateTime endTime)
        {
            Room = room;
            StartTime = startTime;
            EndTime = endTime;

        }

    }
}