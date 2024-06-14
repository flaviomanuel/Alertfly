using Alertfly.App.Core.Entities;
using MediatR;

namespace Alertfly.App.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>?>
    {
    }
}
