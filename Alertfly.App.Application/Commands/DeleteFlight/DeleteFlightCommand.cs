using MediatR;

namespace Alertfly.App.Application.Commands.DeleteFlight
{
    public class DeleteFlightCommand : IRequest<Unit>
    {
        public DeleteFlightCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
