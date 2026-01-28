using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

using ConferenceBookingDomain;
public class BookingLogic
{
    public BookingLogic()
    {
        DefaultRooms();
        AddDummyBookings();
    }

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

    public void DefaultRooms()
    {
        AddRoom(new ConferenceRoom("001", 15));
        AddRoom(new ConferenceRoom("002", 12));
        AddRoom(new ConferenceRoom("003", 20));
        AddRoom(new ConferenceRoom("004", 17));
        AddRoom(new ConferenceRoom("005", 10));
    }

    public List<ConferenceRoom> GetRooms()
    {
        if (!_rooms.Any())
        {
            throw new NoConferenceRoomsException();
        }
        return _rooms.Values.ToList();
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
    private void AddDummyBookings()
    {
        var room1 = _rooms["001"];
        var room2 = _rooms["002"];
        var room3 = _rooms["003"];


        Bookings.Add(new Booking(new BookingRequest(
            room1,
            new DateTime(2026, 2, 2, 9, 0, 0),
            new DateTime(2026, 2, 2, 10, 0, 0)
        )));

        Bookings.Add(new Booking(new BookingRequest(
            room2,
            new DateTime(2026, 2, 2, 11, 0, 0),
            new DateTime(2026, 2, 2, 12, 30, 0)
        )));


        Bookings.Add(new Booking(new BookingRequest(
            room3,
            new DateTime(2026, 2, 4, 14, 0, 0),  // 14:00
            new DateTime(2026, 2, 4, 16, 0, 0)   // 16:00
        )));


        Bookings.Add(new Booking(new BookingRequest(
            room1,
            new DateTime(2026, 2, 6, 10, 0, 0),  // 10:00
            new DateTime(2026, 2, 6, 11, 30, 0)  // 11:30
        )));
    }



    public void DisplayBookings()
    {
        Console.WriteLine("\nCurrent Bookings:");
        if (Bookings.Count == 0)
        {
            throw new NoBookingsException();
        }

        foreach (var b in Bookings)
        {
            Console.WriteLine($"{b.Room.RoomNumber}: {b.StartTime} - {b.EndTime} ({b.Status})");
        }
    }

    public async Task BookingHistory(string filepath)
{
    
    string json = JsonSerializer.Serialize(Bookings);
    await File.WriteAllTextAsync(filepath, json);
}

public async Task <List<BookingRequest>> ReadHistoryAsync(string filepath)
    {
        if(File.Exists(filepath))
        {
            string json = await File.ReadAllTextAsync(filepath);
            return JsonSerializer.Deserialize<List<BookingRequest>>(json) ?? new List<BookingRequest>();
        }
        else
        {
            throw new FileNotFoundException("History file not found");
        }
        
    }





}