using ConferenceBookingDomain;
using System;

public class Program
{
    public static string Menu()
    {
        Console.WriteLine("\nMenu" +
        "\n1. Display Conference Rooms" +
        "\n2. Display bookings" +
        "\n3. Make a booking" +
        "\n4. Cancel a booking" +
        "\n5. Write bookings to file" +
        "\n6. Read saved bookings from file" +
        "\n7. Exit");
        Console.Write("\nEnter an option: ");
        string choice = Console.ReadLine();
        return choice;
    }

    static async Task Main()
    {
        Console.WriteLine("Conference Room Booking System");
        Console.WriteLine("------------------------------");

        var logic = new BookingLogic();

        bool exit = false;

        while (exit == false)
        {
            string choice = Menu();
            switch (choice)
            {
                case "1":

                    Console.WriteLine("Rooms in the system:");
                    try
                    {

                        foreach (var room in logic.GetRooms())
                        {
                            Console.WriteLine(room);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "2":
                    try
                    {
                        logic.DisplayBookings();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "3":


                    try
                    {
                        Console.Write("\nEnter room number: ");
                        string roomNumber = Console.ReadLine();

                        var roomToBook = logic.GetRooms()
                            .FirstOrDefault(r => r.RoomNumber == roomNumber);

                        if (roomToBook == null)
                        {
                            Console.WriteLine("Room not found.");
                            break;
                        }
                        Console.Write("Enter start date and time (yyyy-MM-dd HH:mm): ");
                        DateTime startTime = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter end date and time (yyyy-MM-dd HH:mm): ");
                        DateTime endTime = DateTime.Parse(Console.ReadLine());

                        var request = new BookingRequest(roomToBook, startTime, endTime);


                        var result = logic.ProcessBooking(request);

                        Console.WriteLine(result.message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }








                    break;
                case "4":
                    if (logic.Bookings.Count == 0)
                    {
                        Console.WriteLine("No bookings to cancel.");
                        break;
                    }

                    for (int i = 0; i < logic.Bookings.Count; i++)
                    {
                        var b = logic.Bookings[i];
                        Console.WriteLine(
                            $"{i + 1}. Room {b.Room.RoomNumber} | {b.StartTime} - {b.EndTime} | {b.Status}"
                        );
                    }

                    Console.Write("\nSelect booking number to cancel: ");
                    int choiceToCancel = int.Parse(Console.ReadLine()) - 1;



                    if (choiceToCancel < 0 || choiceToCancel >= logic.Bookings.Count)
                    {
                        Console.WriteLine("Invalid selection.");
                        break;
                    }

                    try
                    {
                        logic.Bookings[choiceToCancel].Cancel();
                        Console.WriteLine("Booking cancelled successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }



                    break;
                case "5":
                    try
                    {
                        await logic.BookingHistory("history.json");
                        Console.WriteLine("Bookings saved!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to save Calculator history because: {ex.Message}");
                    }


                    break;

                case "6":
                    try
                    {
                        await logic.BookingHistory("history.json");
                        List<BookingRequest> history = await logic.ReadHistoryAsync("history.json");

                        if (history.Count == 0)
                        {
                            Console.WriteLine("No bookings in history.");
                        }
                        else
                        {
                            Console.WriteLine("\nBooking History:");
                            foreach (var b in history)
                            {
                                Console.WriteLine($"Room {b.Room.RoomNumber} | {b.StartTime} - {b.EndTime}");
                            }
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine($"History file not found: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to read or save file: {ex.Message}");
                    }


                    break;



                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\n!!! Choose a valid option !!!");
                    Console.WriteLine("------------------------");


                    break;
            }

        }
        ;









    }
}
