using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacro2.Strategies
{
    public interface ITypeStrategy
    {
        double CalculateCost(double subtotal);
    }
}
