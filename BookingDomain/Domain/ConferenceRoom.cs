namespace ConferenceBookingDomain
{
    public class ConferenceRoom
    {
        //Roomtype

        public int ID { get; }

        public string RoomNumber { get; }

        public int Capacity { get; }

        public RoomStatus Status { get; set; }

        public ConferenceRoom(int id, string roomNumber, int capacity, RoomStatus status)
        {
        

            ID = id;
            RoomNumber = roomNumber;
            Capacity = capacity;
            Status = status;
        }

        

        





    }
}
