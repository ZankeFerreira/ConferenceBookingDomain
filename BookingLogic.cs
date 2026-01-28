using System;

using ConferenceBookingDomain;
public class BookingLogic
{
    //Lookup rooms with room number
    public Dictionary<string, ConferenceRoom> _rooms = new Dictionary<string, ConferenceRoom>();

    //List of bookings
    public List<Booking> Bookings { get; } = new List<Booking>();

    public List<ConferenceRoom> Rooms
    {
        get
        {
            List<ConferenceRoom> roomList = new List<ConferenceRoom>();
            foreach (var i in _rooms)
            {
                var room = i.Value;
                roomList.Add(room);
            }

            return roomList;
        }
    }

 
    public void AddRoom(ConferenceRoom room)
    {

        if (room == null)
        {
            throw new Exception("Room cannot be null");
        }

        if (_rooms.ContainsKey(room.RoomNumber))
        {
            throw new Exception("Room already exists");
        }

        _rooms[room.RoomNumber] = room;
    }

    public (bool success, string message, Booking booking) ProcessBooking(BookingRequest request)
    {
    
        if (!_rooms.ContainsKey(request.Room.RoomNumber))
            return (false, $"Room {request.Room.RoomNumber} does not exist", null);

        var room = _rooms[request.Room.RoomNumber];


    
        var rooms = _rooms[request.Room.RoomNumber]; 
        if (rooms.Status != RoomStatus.Available)     
        {
            return (false, $"Room {room.RoomNumber} is not available", null);
        }

       
        foreach (var b in Bookings)
        {
            if (b.Room.RoomNumber == room.RoomNumber && b.Status == BookingStatus.Active)
            {
                if (b.Overlaps(request.StartTime, request.EndTime))
                {
                    return (false, $"Room {room.RoomNumber} is already booked during this time", null);
                }
            }
        }

      
        try
        {
            var booking = new Booking(request);
            Bookings.Add(booking);
            return (true, "Booking successful", booking);
        }
        catch (Exception ex)
        {
            return (false, ex.Message, null);
        }
    }

  
    public void DisplayBookings()
    {
        Console.WriteLine("\nCurrent Bookings:");
        if (Bookings.Count == 0)
        {
            Console.WriteLine("No bookings.");
            return;
        }

        foreach (var b in Bookings)
        {
            Console.WriteLine($"{b.Room.RoomNumber}: {b.StartTime} - {b.EndTime} ({b.Status})");
        }
    }




}