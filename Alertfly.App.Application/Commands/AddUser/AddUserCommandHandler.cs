using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;

namespace Alertfly.App.Application.Commands.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email, request.PhoneNumber);

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}
