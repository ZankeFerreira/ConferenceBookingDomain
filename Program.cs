using ConferenceBookingDomain;
using System;

public class Program
{
    static void Main()
    {
        var logic = new BookingLogic();

        var room1 = new ConferenceRoom("001", 15);
        var room2 = new ConferenceRoom("002", 12);
        var room3 = new ConferenceRoom("003", 20);
        var room4 = new ConferenceRoom("004", 17);
        var room5 = new ConferenceRoom("005", 10);


        logic.AddRoom(room1);
        logic.AddRoom(room2);
        logic.AddRoom(room3);
        logic.AddRoom(room4);
        logic.AddRoom(room5);


        Console.WriteLine("Rooms in the system:");
        foreach (var room in logic.Rooms)
        {
            Console.WriteLine($"{room.RoomNumber} (Capacity: {room.Capacity}, Status: {room.Status})");
        }


        var now = DateTime.Now;
        var request1 = new BookingRequest(room1, now.AddMinutes(5), now.AddMinutes(65));   // valid
        var request2 = new BookingRequest(room1, now.AddMinutes(50), now.AddMinutes(120)); // overlaps
        var request3 = new BookingRequest(room2, now.AddMinutes(10), now.AddMinutes(70));  // valid
        var request4 = new BookingRequest(room3, now.AddMinutes(-10), now.AddMinutes(30)); // start in past

        var requests = new BookingRequest[] { request1, request2, request3, request4 };

    
        foreach (var req in requests)
        {
            var (success, message, booking) = logic.ProcessBooking(req);
            Console.WriteLine($"Booking for room {req.Room.RoomNumber} from {req.StartTime:t} to {req.EndTime:t}: {(success ? "Accepted" : "Rejected")} - {message}");
        }

       
        logic.DisplayBookings();

        Booking firstActive = null;
        foreach (var b in logic.Bookings)
        {
            if (b.Status == BookingStatus.Active)
            {
                firstActive = b;
                break;
            }
        }

        if (firstActive != null)
        {
            Console.WriteLine($"\nCancelling booking: {firstActive.Room.RoomNumber} ({firstActive.StartTime:t}-{firstActive.EndTime:t})");
            var cancelledBooking = firstActive.Cancel();
            Console.WriteLine($"Status after cancellation: {cancelledBooking.Status}");
        }

        logic.DisplayBookings();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
