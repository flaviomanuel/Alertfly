using MediatR;

namespace Alertfly.App.Application.Commands.UpdateUserAlertAt
{
    public class UpdateUserAlertAtCommand : IRequest<Unit>
    {
        public UpdateUserAlertAtCommand(Guid id, DateTime alertAt)
        {
            Id = id;
            AlertAt = alertAt;
        }

        public Guid Id { get; private set; }
        public DateTime AlertAt { get; private set; }
     
    }
}
