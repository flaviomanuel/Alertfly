using Alertfly.App.Application.ViewModels;
using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alertfly.App.Application.Queries.GetUserFlightById
{
    public class GetUserFlightByIdQueryHandler : IRequestHandler<GetUserFlightByIdQuery, UserFlightViewModel?>
    {
        private readonly IUserFlightRepository _userFlightRepository;

        public GetUserFlightByIdQueryHandler(IUserFlightRepository userFlightRepository)
        {
            _userFlightRepository = userFlightRepository;
        }

        public async Task<UserFlightViewModel?> Handle(GetUserFlightByIdQuery request, CancellationToken cancellationToken)
        {
            var userFlight = await _userFlightRepository.GetByIdAsync(request.Id);

            if (userFlight is null) return null;

            var userFlightViewModel = new UserFlightViewModel(userFlight.Id, userFlight.UserId, userFlight.FlightId, userFlight.AlertAt, userFlight.CreatedAt);

            return userFlightViewModel;
        }
    }
}
