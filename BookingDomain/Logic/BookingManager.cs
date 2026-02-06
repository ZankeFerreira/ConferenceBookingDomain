
namespace ConferenceBookingDomain
{
    
    


    public class BookingManager     //All business rules
    {
        //Properties
        private readonly List<Booking> _bookings = new List<Booking>();
        private List<ConferenceRoom> _rooms = new List<ConferenceRoom>();

        private readonly IBookingStore _store;
        //Method

        public BookingManager(IBookingStore store)
        {
            _bookings = new List<Booking>();
            _store = store;
            SeedData data = new SeedData();
            _rooms = data.SeedRooms();

        }
        public IReadOnlyList<Booking> GetBookings()
        {
            return _bookings.ToList();
        }
        public IReadOnlyList<ConferenceRoom> GetRooms()
        {
            return _rooms.ToList();
        }

        public async Task<Booking> CreateBooking(BookingRequest request)
        {
            if (request.Room == null)
            {
                throw new InvalidBookingException();
            }
            if (request.StartTime >= request.EndTime)
            {
                throw new InvalidBookingException(); 
            }
            bool overlaps = _bookings.Any(b => b.Room == request.Room && b.Status == BookingStatus.Confirmed && request.StartTime < b.EndTime && request.EndTime > b.StartTime);

            if (overlaps)
            {
                throw new BookingConflictException();
            }

            Booking booking = new Booking(request.Room, request.StartTime, request.EndTime);

            booking.Confirm();
            _bookings.Add(booking);

            await _store.SaveAsync(_bookings);

            return booking;

        }

        public async Task<bool> DeleteBooking(Guid id)
        {
            var bookingToRemove = _bookings.FirstOrDefault(b => b.Id == id);
            if (bookingToRemove == null)
            {
                throw new BookingNotFoundException(id);
            }

            _bookings.Remove(bookingToRemove);
            await _store.SaveAsync(_bookings);

            return true;
        }

        public void UpdateRoomStatus(int id, RoomStatus newStatus)
        {
            var room = _rooms.FirstOrDefault(r => r.ID == id);
            if (room == null) {
                throw new RoomNotFoundException(id);
            }

            room.Status = newStatus;
            
        }

    }
}











