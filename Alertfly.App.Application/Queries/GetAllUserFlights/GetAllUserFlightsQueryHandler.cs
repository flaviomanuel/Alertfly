using Alertfly.App.Application.ViewModels;
using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Queries.GetAllUserFlights
{
    public class GetAllUserFlightsQueryHandler : IRequestHandler<GetAllUserFlightsQuery, List<UserFlightViewModel>?>
    {
        private readonly IUserFlightRepository _userFlightRepository;

        public GetAllUserFlightsQueryHandler(IUserFlightRepository userFlightRepository)
        {
            _userFlightRepository = userFlightRepository;
        }

        public async Task<List<UserFlightViewModel>?> Handle(GetAllUserFlightsQuery request, CancellationToken cancellationToken)
        {
            var userFlights = await _userFlightRepository.GetAllAsync();

            if (userFlights == null) return null;

            var userFlightsViewModels = userFlights
                .Select(x => new UserFlightViewModel(x.Id, x.UserId, x.FlightId, x.AlertAt, x.CreatedAt))
                .ToList();

            return userFlightsViewModels;
        }
    }
}
