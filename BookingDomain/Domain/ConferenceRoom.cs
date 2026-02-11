namespace ConferenceBookingDomain
{
    public class ConferenceRoom
    {
        //Roomtype

        public int Id { get; set;}

        public string RoomID { get; set;}       

        public string Location {get;set;}

        public int Capacity { get;set; }

        public RoomStatus Status { get; set; }  //Is active or not

        public ConferenceRoom(int id, string roomId, string location, int capacity, RoomStatus status)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be positive.");

            Id = id;
            RoomID = roomId;
            Location = location;
            Capacity = capacity;
            Status = status;
        }
        private ConferenceRoom(){}
   }
}
