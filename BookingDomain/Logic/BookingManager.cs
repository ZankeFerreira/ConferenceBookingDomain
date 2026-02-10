using BookingDomain.Persistence;
namespace ConferenceBookingDomain
{
    public class BookingManager     //All business rules
    {
        //Properties
        private readonly List<Booking> _bookings = new List<Booking>();

        private readonly IBookingStore _store;
        //Method

        public BookingManager(IBookingStore store)
        {
            _bookings = new List<Booking>(); 
            _store = store;


        }
        public IReadOnlyList<Booking> GetBookings()
        {
            return _bookings.ToList();
        }
        public async Task<List<ConferenceRoom>> LoadRoomsAsync()
        {
            return new SeedData().SeedRooms();
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

            Booking booking = new Booking(request.Room, request.StartTime, request.EndTime)
            {
                CreatedBy = request.UserId,
                BookingFor = request.VisitorName
            };

            booking.Confirm();
            _bookings.Add(booking);

            await _store.SaveAsync(_bookings);

            return booking;

        }

        public async Task<bool> DeleteBooking(int id, string currentUserId, bool isAdmin)
        {
            var allBookings = await _store.LoadAsync();

            var bookingToRemove = allBookings.FirstOrDefault(b => b.Id == id);
            if (bookingToRemove == null)
            {
                throw new BookingNotFoundException(id);
            }
            if (!isAdmin && bookingToRemove.CreatedBy != currentUserId)
            {
                throw new ForbiddenAccessException();
            }



            await _store.DeleteAsync(id);

            return true;
        }

        public async Task UpdateRoomStatus(int id, RoomStatus newStatus)
        {
            var rooms = await _store.LoadRoomsAsync();
            var room = rooms.FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                throw new RoomNotFoundException(id);
            }

            room.Status = newStatus;

            await _store.UpdateRoomAsync(room);
        }

        public async Task<IReadOnlyList<ConferenceRoom>> GetRooms()
{
    return await _store.LoadRoomsAsync();
}

    }
}
