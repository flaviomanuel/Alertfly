using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Commands.DeleteUserFlight
{
    public class DeleteUserFlightCommandHandler : IRequestHandler<DeleteUserFlightCommand, Unit>
    {
        private readonly IUserFlightRepository _userFlightRepository;

        public DeleteUserFlightCommandHandler(IUserFlightRepository userFlightRepository)
        {
            _userFlightRepository = userFlightRepository;
        }

        public async Task<Unit> Handle(DeleteUserFlightCommand request, CancellationToken cancellationToken)
        {
            var userFlight = await _userFlightRepository.GetByIdAsync(request.Id);

            if (userFlight == null) throw new Exception("UserFlight Not Found");

            await _userFlightRepository.DeleteAsync(userFlight);

            return Unit.Value;
        }
    }
}
