using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alertfly.App.Application.Commands.AddFlight
{
    public class AddFlightCommandHandler : IRequestHandler<AddFlightCommand, Unit>
    {
        private readonly IFlightRepository _flightRepository;

        public AddFlightCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Unit> Handle(AddFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = new Flight(request.Title, request.Origin,request.Destiny, request.FlightDate);

            await _flightRepository.AddAsync(flight);

            return Unit.Value;
        }
    }
}
