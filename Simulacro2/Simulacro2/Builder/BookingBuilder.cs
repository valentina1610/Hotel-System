using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacro2.Models;
using Simulacro2.Strategies;
using Simulacro2.Views;

namespace Simulacro2.Builder
{
    public class BookingBuilder : IBookingBuilder
    {
        private Booking _booking;
        public BookingBuilder()
        {
            _booking = new Booking
            {
                roomsList = new List<Room>()
            };
        }
        public void SetClient(string clientName, int cell)
        {
            _booking.clientName = clientName;
            _booking.cell = cell;
        }
        public void AddRoom(int number, double price, int nights)
        {
            _booking.roomsList.Add(new Room(number, price, nights));
        }
        public void SetTypeRoom(ITypeStrategy type)
        {
            _booking.typeCostStrategy = type;
            if (type is PremiumType)
                _booking.typeName= "Premium";
            else if (type is StandardType)
                _booking.typeName = "Standard";
            else if (type is SuiteType)
                _booking.typeName = "Suite";
        }

        public Booking Build()
        {
            if (_booking.roomsList.Count == 0) BookingView.Print("[ERROR]: DEBE AGREGAR AL MENOS 1 HABITACION");
            if (string.IsNullOrWhiteSpace(_booking.clientName)) BookingView.Print("DEBE AGREGAR UN CLIENTE");
            _booking.CalculateTotal();
            return _booking;
        }
    }
}
