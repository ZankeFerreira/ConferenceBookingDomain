

namespace ConferenceBookingDomain
{

    public record BookingRequest
    {
        public string UserId{get;set;}
        public string? VisitorName{get;set;}
        public ConferenceRoom Room { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public int Capacity {get; set;}


        public BookingRequest(
            ConferenceRoom room,
            DateTime startTime,
            DateTime endTime,
            int capacity)
        {
            Room = room;
            StartTime = startTime;
            EndTime = endTime;
            Capacity = capacity;

        }

    }
}