namespace ConferenceBookingDomain
{
    public class ConferenceRoom
    {
        //Roomtype

        public int Id { get; set;}

        public string Location { get; set;}       //Location

        public int Capacity { get;set; }

        public RoomStatus Status { get; set; }  //Is active or not

        public ConferenceRoom(int id, string loaction, int capacity, RoomStatus status)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be positive.");

            Id = id;
            Location = loaction;
            Capacity = capacity;
            Status = status;
        }
        private ConferenceRoom(){}
   }
}
