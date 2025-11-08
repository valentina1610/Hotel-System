using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacro2.Builder;
using Simulacro2.Models;
using Simulacro2.Repositories;
using Simulacro2.Services;
using Simulacro2.Strategies;
using Simulacro2.Views;

namespace Simulacro2.Controllers
{
    public class BookingFacade
    {
        private readonly IBookingBuilder _builder;
        private readonly BookingService _service;
        private readonly IRepository<Booking> _repo;

        public BookingFacade(IBookingBuilder _builder, BookingService _service, IRepository<Booking> _repo)
        {
            this._builder = _builder;
            this._service = _service;
            this._repo = _repo;
        }

        public void SetClient(string clientName, int cell)
        {
            _builder.SetClient(clientName, cell);
        }

        public void AddRoom(int number, double price, int nights)
        {
            _builder.AddRoom(number, price, nights);
        }
        public void SetTypeRoom(string type)
        {
            ITypeStrategy strategy = null;
            switch (type.ToLower())
            {
                case "standard":
                    {
                        strategy = new StandardType();
                        break;
                    }
                case "premium":
                    {
                        strategy = new PremiumType();
                        break;
                    }
                case "suite":
                    {
                        strategy = new SuiteType();
                        break;
                    }
            }
            _builder.SetTypeRoom(strategy);
        }

        public void ConfirmBooking()
        {
            var booking = _builder.Build();
            _service.Confirm(booking);
            _repo.Save(booking);
        }
    }
}
