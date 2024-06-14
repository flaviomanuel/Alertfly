using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null) throw new Exception("User not Found");

            return user;
        }
    }
}
