using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Queries.GetAllUserFlights
{
    public class GetAllUserFlightsQueryHandler : IRequestHandler<GetAllUserFlightsQuery, List<UserFlight>?>
    {
        private readonly IUserFlightRepository _userFlightRepository;

        public GetAllUserFlightsQueryHandler(IUserFlightRepository userFlightRepository)
        {
            _userFlightRepository = userFlightRepository;
        }

        public async Task<List<UserFlight>?> Handle(GetAllUserFlightsQuery request, CancellationToken cancellationToken)
        {
            var userFlights = await _userFlightRepository.GetAllAsync();

            return userFlights;
        }
    }
}
