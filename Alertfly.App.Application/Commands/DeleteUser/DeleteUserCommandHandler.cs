using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null) throw new Exception("User not Found");

            await _userRepository.DeleteByIdAsync(user);

            return Unit.Value;
        }
    }
}
