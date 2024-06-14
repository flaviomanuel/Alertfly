using Alertfly.App.Core.Entities;
using MediatR;

namespace Alertfly.App.Application.Queries.GetAllUserFlights
{
    public class GetAllUserFlightsQuery : IRequest<List<UserFlight>?>
    {
    }
}
