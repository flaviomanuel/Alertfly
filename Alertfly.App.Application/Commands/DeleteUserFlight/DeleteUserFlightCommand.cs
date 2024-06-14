using MediatR;

namespace Alertfly.App.Application.Commands.DeleteUserFlight
{
    public class DeleteUserFlightCommand : IRequest<Unit>
    {
        public DeleteUserFlightCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
