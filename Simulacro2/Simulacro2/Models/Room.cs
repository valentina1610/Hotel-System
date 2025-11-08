using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacro2.Models
{
    public class Room
    {
        public int number { get; set; }
        public double price { get; set; }
        public int nights { get; set; }

        public Room(int number, double price, int nights)
        {
            this.number = number;
            this.price = price;
            this.nights = nights;
        }
        public Room() { }

        public double Subtotal()
        {
            return price * nights;
        }


    }
}
