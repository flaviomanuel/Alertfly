using Alertfly.App.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alertfly.App.Application.Commands.AddFlight
{
    public class AddFlightCommand : IRequest<Unit>
    {
        public AddFlightCommand(string title, string origin, string destiny, DateTime flightDate)
        {  
            Title = title;
            Origin = origin;
            Destiny = destiny;
            FlightDate = flightDate;
        }
        public string Title { get; private set; }
        public string Origin { get; private set; }
        public string Destiny { get; private set; }
        public DateTime FlightDate { get; private set; }
    }
}
