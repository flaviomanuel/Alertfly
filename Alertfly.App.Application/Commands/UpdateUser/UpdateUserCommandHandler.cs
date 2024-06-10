using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userFound = await _userRepository.GetByIdAsync(request.Id);

            if (userFound is null) throw new Exception("User not Found");

            var newUser = new User(request.Name, request.Email, request.PhoneNumber);

            await _userRepository.UpdateAsync(newUser);

            return Unit.Value;
        }
    }
}