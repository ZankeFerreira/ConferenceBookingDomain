using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ConferenceBookingDomain;

public class BookingDbContext: IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options): base(options)
    {
        
    }

    public DbSet <Booking> Booking{get;set;}
    public DbSet <ConferenceRoom> ConferenceRooms {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>().HasKey(c=> c.Id);
        modelBuilder.Entity<ConferenceRoom>().HasKey(c=> c.Id);
        var seeder = new SeedData();
        modelBuilder.Entity<ConferenceRoom>().HasData(seeder.SeedRooms().ToArray());


    }
}