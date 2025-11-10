using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Simulacro2.Strategies;

namespace Simulacro2.Models
{
    public class Booking
    {
        public List<Room> roomsList { get; set; } = new List<Room>();
        public string clientName { get; set; }
        public int cell { get; set; }
        public double total { get; set; }

        [JsonIgnore]
        public ITypeStrategy typeCostStrategy { get; set; }

        public string typeName { get; set; }

        public Booking(string clientName, int cell, double total, ITypeStrategy typeCostStrategy, string typeName)
        {
            this.clientName = clientName;
            this.cell = cell;
            this.total = total;
            this.typeCostStrategy = typeCostStrategy;
            this.typeName = typeName;
        }
        public Booking() { }
        public double CalculateSubtotal()
        {
            double subtotal = 0;
            foreach (var r in roomsList)
            {
                subtotal += r.Subtotal();
            }
            return subtotal;
        }
        public void CalculateTotal()
        {
            double subtotal = CalculateSubtotal();
            total = typeCostStrategy != null ? typeCostStrategy.CalculateCost(subtotal) : subtotal;
        }
    }
}
