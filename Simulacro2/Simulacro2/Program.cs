using System;
using System.ComponentModel.Design;
using Simulacro2.Builder;
using Simulacro2.Controllers;
using Simulacro2.Models;
using Simulacro2.Observers;
using Simulacro2.Repositories;
using Simulacro2.Services;
using Simulacro2.Views;

namespace Simulacro2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new RepositoryJson<Booking>();
            var builder = new BookingBuilder();
            var service = new BookingService();
            service.Suscribe(new ClientObserver());
            service.Suscribe(new ReceptionObserver());

            var facade = new BookingFacade(builder, service, repo);

            bool running = true;
            while (running)
            {
                Console.WriteLine("===== HOTEL SYSTEM =====");
                Console.WriteLine("1. Create a new booking");
                Console.WriteLine("2. Show all bookings");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            {
                                //---- CLIENT INFO -----
                                var (clientName, cell) = BookingView.AddClient();
                                facade.SetClient(clientName, cell);

                                //----- TYPE OF THE ROOM -----
                                string type = BookingView.AddRoomType();
                                facade.SetTypeCost(type);

                                //----ADD ROOM----
                                var rooms = BookingView.AddRooms();
                                facade.SetRooms(rooms);

                                //---- CONFIRM ORDER -----
                                facade.ConfirmBooking();
                                BookingView.Print("Press any key to go back to menu.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case "2":
                            {
                                Console.Clear();
                                var allBookings = repo.GetAll();
                                foreach (var b in allBookings)
                                {
                                    BookingView.ShowBooking(b);
                                }
                                BookingView.Print("Press any key to go back to menu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case "3":
                            {
                                running = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("[ERROR]: Invalid choice.");
                                break;
                            }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[ERROR]: {ex.Message}");
                }
                
            }


        }
    }
}
