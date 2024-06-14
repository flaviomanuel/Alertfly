using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Commands.DeleteFlight
{
    internal class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, Unit>
    {
        private readonly IFlightRepository _flightRepository;

        public DeleteFlightCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Unit> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetByIdAsync(request.Id);

            if (flight is null) throw new Exception("Flight Not Found");

            await _flightRepository.DeleteAsync(flight);

            return Unit.Value;
        }
    }
}
