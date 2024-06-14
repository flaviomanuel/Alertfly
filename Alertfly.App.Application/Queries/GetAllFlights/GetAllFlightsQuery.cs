using Alertfly.App.Core.Entities;
using MediatR;

namespace Alertfly.App.Application.Queries.GetAllFlights
{
    public class GetAllFlightsQuery : IRequest<List<Flight>?>
    {
        
    }
}
