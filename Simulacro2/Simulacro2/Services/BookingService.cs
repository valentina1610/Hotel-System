using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Simulacro2.Models;
using Simulacro2.Observers;
using Simulacro2.Views;

namespace Simulacro2.Services
{
    public class BookingService
    {
        private readonly List<IBookingObserver> _observersList = new();

        public void Suscribe(IBookingObserver observer) => _observersList.Add(observer);
        public void Unsuscribe(IBookingObserver observer) => _observersList.Remove(observer);

        public void Confirm(Booking booking)
        {
            Notify(booking);
        }

        public void Notify(Booking booking)
        {
            foreach (var o in _observersList)
            {
                try
                {
                    o.OnBookingConfirmed(booking);
                }
                catch (Exception ex)
                {
                    BookingView.Print($"[ERROR]: Notify error: {ex.Message}");
                }
            }
        }
    }
}
