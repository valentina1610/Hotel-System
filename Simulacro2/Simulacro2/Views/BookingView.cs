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
            string clientName = GetValidInput();

            Print("Enter the client's cellphone: ");
            int cell = int.Parse(GetValidInput(true));

            Print("Press any key to continue");
            Console.ReadKey();
            return (clientName, cell);
        }

        public static string AddRoomType()
        {
            Console.Clear();
            Print("Enter room type for the booking (Standard / Premium / Suite): ");
            string type = GetValidInput(false,false,true).ToLower();

            Print("Press any key to continue");
            Console.ReadKey();
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
                int number = int.Parse(GetValidInput(true));

                // Precio por noche
                Print("Enter price per night: ");
                double price = double.Parse(GetValidInput(true));

                // Cantidad de noches
                Print("Enter number of nights: ");
                int nights = int.Parse(GetValidInput(true));

                // Agregar habitación a la lista
                rooms.Add(new Room(number, price, nights));

                // Preguntar si quiere agregar otra habitación
                Print("Add another room? (y/n): ");
                string more = GetValidInput(false,true).ToLower();
                if (more == "n")
                    adding = false;
                else
                    adding = true;
            }
            Print("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            return rooms;
        }

        public static void ShowBooking(Booking booking)
        {
            Console.WriteLine("| ---------- BOOKING DETAILS ------------ |");
            Console.WriteLine($"| Client: {booking.clientName} - Cellphone: {booking.cell}");
            Console.WriteLine($"| Room Type: {booking.typeName}");
            Console.WriteLine("| Rooms:");

            foreach (var room in booking.roomsList)
            {
                Console.WriteLine($"| Room {room.number} - ${room.price} x {room.nights} nights = ${room.Subtotal()}");
            }

            Console.WriteLine($"| Final Price: ${booking.total}");
            Console.WriteLine("-------------------------------------------\n");
        }

        public static string GetValidInput(bool isNumeric = false, bool isYorN = false, bool isRoomType = false)
        {
            string input;
            bool valid = false;
            do
            {
                input = Console.ReadLine().ToLower();
                if (isNumeric && !isYorN && !isRoomType && double.TryParse(input, out double _) && !string.IsNullOrEmpty(input))
                {
                    valid = true;
                }
                else if (!isNumeric && isYorN && !isRoomType && (input =="y") || (input == "n") && !string.IsNullOrEmpty(input))
                {
                    valid = true;
                }
                else if (!isNumeric && !isYorN && !isRoomType && !string.IsNullOrEmpty(input))
                {
                    valid = true;
                }
                else if (!isNumeric && !isYorN && isRoomType && (input == "standard") || (input == "premium") || (input == "suite") && !string.IsNullOrEmpty(input))
                {
                    valid = true;
                }
                else
                {
                    Print("[ERROR]: invalid input, please try again!");
                }
            } while (!valid);
            return input;
        }

        public static void Print(string msj)
        {
            Console.WriteLine(msj);
        }
    }
}
