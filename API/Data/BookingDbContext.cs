using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ConferenceBookingDomain;
using ConferenceBookingDomain.Domain;


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

        modelBuilder.Entity<Booking>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Booking>()
            .HasOne(c => c.Room)
            .WithMany()
            .HasForeignKey(c => c.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

       
       

        modelBuilder.Entity<ConferenceRoom>().HasKey(c => c.Id);
        var seeder = new SeedData();
        modelBuilder.Entity<ConferenceRoom>().HasData(seeder.SeedRooms().ToArray());


    }
}
