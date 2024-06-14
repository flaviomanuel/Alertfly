using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alertfly.App.Application.Queries.GetFlightById
{
    public class GetFlightByIdQueryHandler : IRequestHandler<GetFlightByIdQuery, Flight>
    {
        private readonly IFlightRepository _flightRepository;

        public GetFlightByIdQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Flight> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetByIdAsync(request.Id);

            if (flight is null) throw new Exception("Flight Not Found");

            return flight;
        }
    }
}
