namespace ConferenceBookingDomain;


public record BookingRequest(
    ConferenceRoom room,
    DateTime startTime,
    DateTime endTime
);