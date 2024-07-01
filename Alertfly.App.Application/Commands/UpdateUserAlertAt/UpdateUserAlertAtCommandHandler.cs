using Alertfly.App.Core.Interfaces;
using Alertfly.App.Core.Interfaces.Repositories;
using Alertfly.App.Infrastructure.MessageBus;
using MediatR;

namespace Alertfly.App.Application.Commands.UpdateUserAlertAt
{
    public class UpdateUserAlertAtCommandHandler : IRequestHandler<UpdateUserAlertAtCommand, Unit>
    {
        private readonly IUserFlightRepository _userFlightRepository;

        public UpdateUserAlertAtCommandHandler(IUserFlightRepository userFlightRepository)
        {
            _userFlightRepository = userFlightRepository;
        }

        public async Task<Unit> Handle(UpdateUserAlertAtCommand request, CancellationToken cancellationToken)
        {
            var userFlight = await _userFlightRepository.GetByIdAsync(request.Id);

            if (userFlight == null) throw new Exception("UserFlight Not Found!");


            userFlight.UpdateAlertAt(request.AlertAt);

            await _userFlightRepository.UpdateAsync(userFlight);

            return Unit.Value;
        }
    }
}
