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
        private readonly List<IBookingObserver> _obsList = new();
        public void Suscribe(IBookingObserver obs) => _obsList.Add(obs);
        public void Unsuscribe(IBookingObserver obs) => _obsList.Remove(obs);

        public void Confirm(Booking booking)
        {
            Notify(booking);
        }
        public void Notify(Booking booking)
        {
            foreach (var o in _obsList)
            {
                o.OnBookingConfirmed(booking);
            }
        }
        
    }
}
