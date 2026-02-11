namespace ConferenceBookingDomain
{
    public class SeedData()
    {
        public List<ConferenceRoom> SeedRooms()
        {
            List<ConferenceRoom> ConferenceRoom = new List<ConferenceRoom>()
        {
        new ConferenceRoom (1, "Room A", "Bloemfontein", 10, RoomStatus.Available),
new ConferenceRoom (2, "Room B", "Cape Town", 20, RoomStatus.UnderMaintenance),
new ConferenceRoom (4, "Room D", "Bloemfontein",25,  RoomStatus.Available),
new ConferenceRoom (5, "Room E","Bloemfontein", 30, RoomStatus.Available),
new ConferenceRoom (6, "Room F", "Bloemfontein",10,  RoomStatus.Available),
new ConferenceRoom (7, "Room G", "Cape Town", 20,  RoomStatus.Available),
new ConferenceRoom (8, "Room H", "Bloemfontein",15,  RoomStatus.Available),
new ConferenceRoom (9, "Room I", "Bloemfontein",13,  RoomStatus.Available),
new ConferenceRoom (10, "Room J", "Cape Town", 20,  RoomStatus.Available),
new ConferenceRoom (11, "Room K", "Cape Town", 10,  RoomStatus.Available),
new ConferenceRoom (12, "Room L", "Bloemfontein",5,  RoomStatus.Available),
new ConferenceRoom (13, "Room M", "Bloemfontein",12,  RoomStatus.Available),
new ConferenceRoom (14, "Room N", "Bloemfontein",15,  RoomStatus.Available),
new ConferenceRoom (15, "Room O", "Bloemfontein",12,  RoomStatus.Available),
new ConferenceRoom (16, "Room P", "Cape Town",30,  RoomStatus.Available),
    };
            return ConferenceRoom;
        }
    }
}