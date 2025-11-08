using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacro2.Strategies
{
    public class StandardType : ITypeStrategy
    {
        public double CalculateCost(double subtotal) => subtotal; //gratis
    }
}
