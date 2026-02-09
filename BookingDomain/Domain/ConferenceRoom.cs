namespace ConferenceBookingDomain
{
    public class ConferenceRoom
    {
        //Roomtype

        public int ID { get; set;}

        public string RoomNumber { get; set;}

        public int Capacity { get;set; }

        public RoomStatus Status { get; set; }

        public ConferenceRoom(int id, string roomNumber, int capacity, RoomStatus status)
        {
        

            ID = id;
            RoomNumber = roomNumber;
            Capacity = capacity;
            Status = status;
        }

        

        private ConferenceRoom(){}





    }
}
