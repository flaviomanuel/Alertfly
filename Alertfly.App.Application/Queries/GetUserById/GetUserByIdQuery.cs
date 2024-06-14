using Alertfly.App.Core.Entities;
using MediatR;

namespace Alertfly.App.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

    }
}
