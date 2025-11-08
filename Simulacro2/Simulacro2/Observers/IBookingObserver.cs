using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacro2.Models;

namespace Simulacro2.Observers
{
    public interface IBookingObserver
    {
        void OnBookingConfirmed(Booking booking) { }
    }
}
