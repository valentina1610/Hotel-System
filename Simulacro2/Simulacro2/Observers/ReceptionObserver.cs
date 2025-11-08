using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacro2.Models;
using Simulacro2.Views;

namespace Simulacro2.Observers
{
    public class ReceptionObserver : IBookingObserver
    {
        public void OnBookingConfirmed(Booking booking)
        {
            BookingView.Print("[NOTIFICATION FOR RECEPTION]: New booking confirmed for these rooms:");
            foreach (var r in booking.roomsList)
                Console.WriteLine($"Room {r.number} - {r.price}$ per night - {r.nights} nights");
            BookingView.Print($"Room/s cost {booking.typeName} - Total {booking.total}$");
           
        }
    }
}
