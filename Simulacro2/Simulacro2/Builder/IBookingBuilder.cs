using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacro2.Models;
using Simulacro2.Strategies;

namespace Simulacro2.Builder
{
    public interface IBookingBuilder
    {
        void SetClient(string clientName, int cell); //DATOS DE EL CLIENTE
        void AddRoom(int number, double price, int nights); //AGREGA UNA HABITACION
        void SetTypeRoom(ITypeStrategy type); //DEFINE EL TIPO DE COSTO DE LA HABITACION
        void Reset(); //RESETEA EL BUILDER PARA QUE NO SE ACUMULEN COSAS
        Booking Build();
    }
}
