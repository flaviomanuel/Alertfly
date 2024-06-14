using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Commands.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, Unit>
    {
        private readonly IFlightRepository _flightRepository;

        public UpdateFlightCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Unit> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetByIdAsync(request.Id);

            if (flight is null) throw new Exception("Flight Not Found!");

            flight.Update(request.Title, request.Origin, request.Destiny, request.FlightDate);

            await _flightRepository.UpdateAsync(flight);

            return Unit.Value;
        }
    }
}