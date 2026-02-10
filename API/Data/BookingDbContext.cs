using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ConferenceBookingDomain;

public class BookingDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
    {

    }

    public DbSet<Booking> Booking { get; set; }
    public DbSet<ConferenceRoom> ConferenceRooms { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>().HasKey(c => c.Id);
        modelBuilder.Entity<Booking>().HasData(
           new
           {
               Id = 1,
               Capacity = 5,
               StartTime = DateTime.UtcNow.AddDays(1),
               EndTime = DateTime.UtcNow.AddDays(1).AddHours(1),
               CreatedBy = "Admin",
                BookingFor = "",
               Status = BookingStatus.Confirmed,
               CreatedAt = DateTime.UtcNow,
               RoomId = 1
           },
        new
        {
            Id = 2,
            Capacity = 7,
            StartTime = DateTime.UtcNow.AddDays(2),
            EndTime = DateTime.UtcNow.AddDays(2).AddHours(1),
            CreatedBy = "Admin",
            BookingFor = "",
            Status = BookingStatus.Pending,
            CreatedAt = DateTime.UtcNow,
            RoomId = 2
        }

        );

        modelBuilder.Entity<ConferenceRoom>().HasKey(c => c.Id);
        var seeder = new SeedData();
        modelBuilder.Entity<ConferenceRoom>().HasData(seeder.SeedRooms().ToArray());


    }
}