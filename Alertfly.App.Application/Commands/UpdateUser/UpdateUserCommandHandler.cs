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
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null) throw new Exception("User not Found");

            user.Update(request.Name, request.Email, request.PhoneNumber);

            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}