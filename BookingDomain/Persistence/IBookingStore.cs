using ConferenceBookingDomain;
namespace BookingDomain.Persistence{
public interface IBookingStore
{
    Task SaveAsync(IEnumerable<Booking> bookings);
    Task<List<Booking>> LoadAsync();
    Task DeleteAsync(int id);
    Task<List<ConferenceRoom>> LoadRoomsAsync(); 
    Task UpdateRoomAsync(ConferenceRoom room);

}
}