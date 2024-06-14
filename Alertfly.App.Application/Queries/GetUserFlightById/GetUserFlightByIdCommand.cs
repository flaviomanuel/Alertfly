using Alertfly.App.Core.Entities;
using MediatR;

namespace Alertfly.App.Application.Queries.GetUserFlightById
{
    public class GetUserFlightByIdCommand : IRequest<UserFlight?>
    {
        public GetUserFlightByIdCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
