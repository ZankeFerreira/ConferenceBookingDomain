using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using BookingDomain.Persistence;

namespace ConferenceBookingDomain
{
    public class BookingFileStore : IBookingStore
    {
        private readonly string _filepath;
        private readonly string _directoryPath;

        public BookingFileStore(string directoryPath)
        {
            _directoryPath = directoryPath;
            _filepath = Path.Combine(_directoryPath, "bookings.json");
        }

        public async Task SaveAsync(IEnumerable<Booking> bookings)
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);



            string json = JsonSerializer.Serialize(bookings);
            await File.WriteAllTextAsync(_filepath, json);
        }

        public async Task<List<Booking>> LoadAsync()
        {
            if (!File.Exists(_filepath))
            {
                return new List<Booking>();
            }

            string json = await File.ReadAllTextAsync(_filepath);
            return JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();


        }
        public async Task DeleteAsync(int id)
        {

            var allBookings = await LoadAsync();


            var updatedList = allBookings.Where(b => b.Id != id).ToList();


            await SaveAsync(updatedList);
        }

        public async Task<List<ConferenceRoom>> LoadRoomsAsync()
        {
            
            return new SeedData().SeedRooms();
        }

        public Task UpdateRoomAsync(ConferenceRoom room)
        {
            
            return Task.CompletedTask;
        }






    }
}