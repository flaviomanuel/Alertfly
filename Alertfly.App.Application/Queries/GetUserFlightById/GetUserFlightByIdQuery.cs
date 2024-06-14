using Alertfly.App.Application.ViewModels;
using Alertfly.App.Core.Entities;
using MediatR;

namespace Alertfly.App.Application.Queries.GetUserFlightById
{
    public class GetUserFlightByIdQuery : IRequest<UserFlightViewModel?>
    {
        public GetUserFlightByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
