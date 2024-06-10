using Alertfly.App.Core.Entities;
using MediatR;

namespace Alertfly.App.Application.Commands.AddUser
{
    public class AddUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
