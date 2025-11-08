using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacro2.Models;
using Simulacro2.Views;

namespace Simulacro2.Observers
{
    public class ClientObserver : IBookingObserver
    {
        public void OnBookingConfirmed(Booking booking)
        {
            BookingView.Print($"[NOTIFICATION FOR CLIENT]: Thanks for your reservation in our hotel, {booking.clientName}. Your {booking.typeName} reservation for {booking.total}$ is confirmed!");
        }
    }
}
