using ConferenceBookingDomain;

namespace ConferenceBookingDomain{


public record BookingRequest(
    ConferenceRoom Room,
    DateTime StartTime,
    DateTime EndTime
);
}