using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Queries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>?>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
            
        public async Task<List<User>?> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            return users;
        }
    }
}
