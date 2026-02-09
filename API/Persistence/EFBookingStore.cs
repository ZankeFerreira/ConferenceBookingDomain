using ConferenceBookingDomain;

using Microsoft.EntityFrameworkCore;

public class EFBookingStore{
    private readonly BookingDbContext _context;

    public EFBookingStore(BookingDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(Booking booking)
    {
        _context.Booking.Add(booking);
        await _context.SaveChangesAsync();
    }
    public async Task <IReadOnlyList <Booking> > LoadAllAsync()
    {
        return await _context.Booking.OrderByDescending(c=> c.CreatedAt).ToListAsync();
    }
}
