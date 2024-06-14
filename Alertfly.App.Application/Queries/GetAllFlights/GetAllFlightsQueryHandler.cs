using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Queries.GetAllFlights
{
    public class GetAllFlightsQueryHandler : IRequestHandler<GetAllFlightsQuery, List<Flight>?>
    {
        private readonly IFlightRepository _flightRepository;
        public GetAllFlightsQueryHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public async Task<List<Flight>?> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightRepository.GetAllAsync();
        
            return flights;
        }
    }
}
