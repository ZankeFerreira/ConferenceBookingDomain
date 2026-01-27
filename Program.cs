using System;
using ConferenceBookingDomain;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("=== Conference Room Booking Test ===");

            var room = new ConferenceRoom("A101", 15);
            Console.WriteLine($"Room created: {room.RoomNumber}, Capacity: {room.Capacity}, Status: {room.Status}");

            room.UnderMaintenance();
            Console.WriteLine($"Room status after maintenance: {room.Status}");

            room.Available();
            Console.WriteLine($"Room status after available: {room.Status}");

            var startTime = DateTime.Now.AddHours(2);
            var endTime = DateTime.Now.AddHours(3);

            var request = new BookingRequest(room, startTime, endTime);
            Console.WriteLine("Booking request created");

            var booking = new Booking(request);
            Console.WriteLine($"Booking created: {booking.Room.RoomNumber}");
            Console.WriteLine($"Start: {booking.StartTime}");
            Console.WriteLine($"End: {booking.EndTime}");
            Console.WriteLine($"Status: {booking.Status}");

            booking.Cancel();
            Console.WriteLine($"Booking status after cancel: {booking.Status}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR:");
            Console.WriteLine(ex.Message);
        }
    }
}
