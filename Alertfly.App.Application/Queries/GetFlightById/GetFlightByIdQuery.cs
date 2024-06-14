using Alertfly.App.Core.Entities;
using MediatR;

namespace Alertfly.App.Application.Queries.GetFlightById
{
    public class GetFlightByIdQuery : IRequest<Flight>
    {
        public GetFlightByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
