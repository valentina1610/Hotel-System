using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Simulacro2.Controllers;
using Simulacro2.Models;
using Simulacro2.Strategies;

namespace Simulacro2.Views
{
    public static class BookingView
    {
        public static (string clientName, int cell) AddClient()
        {
            Console.Clear();
            Print("Enter client name: ");
            string clientName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(clientName))
            {
                Print("[ERROR]: Name required, try again!");
                clientName = Console.ReadLine();
            }

            Print("Enter the client's cellphone: ");
            int cell;
            while(!int.TryParse(Console.ReadLine(), out cell)|| cell <= 0)
            {
                Print("[ERROR]: Invalid Cellphone, try again!");
                cell = int.Parse(Console.ReadLine());
            }
            return (clientName, cell);
        }

        public static string AddRoomType()
        {
            Print("Enter room type for the booking (Standard / Premium / Suite): ");
            string type = (Console.ReadLine() ?? "").ToLower();

            while (type != "standard" && type != "premium" && type != "suite")
            {
                Print("[ERROR]: Wrong type, try again! (Standard / Premium / Suite)");
                type = (Console.ReadLine() ?? "").Trim().ToLower();
            }

            return type;
        }

        public static List<Room> AddRooms()
        {
            Console.Clear();
            List<Room> rooms = new List<Room>();
            bool adding = true;

            while (adding)
            {
                // Número de habitación
                Print("Enter room number: ");
                int number;
                while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
                {
                    Print("[ERROR]: Enter a valid room number, try again!");
                }

                // Precio por noche
                Print("Enter price per night: ");
                double price;
                while (!double.TryParse(Console.ReadLine(), out price) || price <= 0)
                {
                    Print("[ERROR]: Enter a valid price, try again!");
                }

                // Cantidad de noches
                Print("Enter number of nights: ");
                int nights;
                while (!int.TryParse(Console.ReadLine(), out nights) || nights <= 0)
                {
                    Print("[ERROR]: Enter a valid number of nights, try again!");
                }

                // Agregar habitación a la lista
                rooms.Add(new Room(number, price, nights));

                // Preguntar si quiere agregar otra habitación
                Print("Add another room? (y/n): ");
                string more = (Console.ReadLine() ?? "").ToLower();
                while (more != "y" && more != "n")
                {
                    Print("[ERROR]: Wrong input, try again! (y/n)");
                    more = (Console.ReadLine() ?? "").Trim().ToLower();
                }

                if (more == "n")
                    adding = false;
                else
                    adding = true;
            }

            return rooms;
        }

        public static void ShowBooking(Booking booking)
        {
            Console.WriteLine("----- BOOKING DETAILS -----");
            Console.WriteLine($"Client: {booking.clientName} - Cellphone: {booking.cell}");
            Console.WriteLine($"Room Type: {booking.typeName}");
            Console.WriteLine("Rooms:");

            foreach (var room in booking.roomsList)
            {
                Console.WriteLine($"Room {room.number} - ${room.price} x {room.nights} nights = ${room.Subtotal()}");
            }

            Console.WriteLine($"Final Price: ${booking.total}");
            Console.WriteLine("---------------------------\n");
        }

        public static void Print(string msj)
        {
            Console.WriteLine(msj);
        }
    }
}
