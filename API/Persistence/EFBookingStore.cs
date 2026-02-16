using ConferenceBookingDomain;

using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace BookingDomain.Persistence;

public class EFBookingStore : IBookingStore
{
    private readonly BookingDbContext _context;

    public EFBookingStore(BookingDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(IEnumerable<Booking> booking)
    {

        _context.Booking.AddRange(booking);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Booking>> LoadAsync()
    {
        return await _context.Booking.Where(c => c.Status == BookingStatus.Confirmed).Include(b => b.Room).OrderByDescending(c => c.CreatedAt).ToListAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var booking = await _context.Booking.FindAsync(id);
        if (booking != null)
        {
           booking.Status = BookingStatus.Cancelled;

            
        }
        await _context.SaveChangesAsync();
        

    }
    public async Task<List<ConferenceRoom>> LoadRoomsAsync()
    {
        
        return await _context.ConferenceRooms.ToListAsync();
    }
    public async Task UpdateRoomAsync(ConferenceRoom room)
{
    _context.ConferenceRooms.Update(room);
    await _context.SaveChangesAsync();
}


}
