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

        public void SetClient(string client, int cell)
        {
            _builder.SetClient(client,cell);
        }
        public void SetRooms(List<Room> listRooms)
        {
            foreach(var r in listRooms)
            {
                _builder.AddRoom(r.number, r.price, r.nights);
            }
        }
        public void SetTypeCost(string type)
        {
            ITypeStrategy typeStrategy = null;
            switch(type)
            {
                case "premium":
                    {
                        typeStrategy = new PremiumType();
                        break;
                    }
                case "standard":
                    {
                        typeStrategy = new StandardType();
                        break;
                    }
                case "suite":
                    {
                        typeStrategy = new SuiteType();
                        break;
                    }
            }
            _builder.SetTypeRoom(typeStrategy);
        }

        public void ConfirmBooking()
        {
            var booking = _builder.Build();
            _service.Notify(booking);
            _repo.Save(booking);

            _builder.Reset();
        }

    }
}
