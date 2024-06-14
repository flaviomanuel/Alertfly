using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Commands.AddUserFlight
{
    internal class AddUserFlightCommandHandler : IRequestHandler<AddUserFlightCommand, Unit>
    {
        private readonly IUserFlightRepository _userFlightRepository;

        public AddUserFlightCommandHandler(IUserFlightRepository userFlightRepository)
        {
            _userFlightRepository = userFlightRepository;
        }

        public async Task<Unit> Handle(AddUserFlightCommand request, CancellationToken cancellationToken)
        {
            var userFlight = new UserFlight(request.UserId, request.FlightId, request.AlertAt);

            await _userFlightRepository.AddAsync(userFlight);

            return Unit.Value;
        }
    }
}
