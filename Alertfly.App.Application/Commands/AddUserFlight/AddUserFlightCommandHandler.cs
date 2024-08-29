using Alertfly.App.Application.ViewModels;
using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;
using System.Text;
using System.Text.Json;

namespace Alertfly.App.Application.Commands.AddUserFlight
{
    internal class AddUserFlightCommandHandler : IRequestHandler<AddUserFlightCommand, Unit>
    {
        private readonly IUserFlightRepository _userFlightRepository;
        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "AlertFlight";
        private const string ROUTING_KEY = "created.AlertFlight";


        public AddUserFlightCommandHandler(IUserFlightRepository userFlightRepository, IMessageBusService messageBusService)
        {
            _userFlightRepository = userFlightRepository;
            _messageBusService = messageBusService;
        }

        public async Task<Unit> Handle(AddUserFlightCommand request, CancellationToken cancellationToken)
        {
            var userFlight = new UserFlight(request.UserId, request.FlightId, request.AlertAt);

            await _userFlightRepository.AddAsync(userFlight);

            var userFlightViewModel = new UserFlightViewModel(userFlight.Id, userFlight.UserId, userFlight.FlightId, userFlight.AlertAt, userFlight.CreatedAt);

            _messageBusService.Publish(userFlightViewModel, QUEUE_NAME, ROUTING_KEY, QUEUE_NAME+"-exchange");

            return Unit.Value;
        }
    }
}
