using Alertfly.App.Core.Entities;
using Alertfly.App.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alertfly.App.Application.Queries.GetUserFlightById
{
    public class GetUserFlightByIdCommandHandler : IRequestHandler<GetUserFlightByIdCommand, UserFlight?>
    {
        private readonly IUserFlightRepository _userFlightRepository;

        public GetUserFlightByIdCommandHandler(IUserFlightRepository userFlightRepository)
        {
            _userFlightRepository = userFlightRepository;
        }

        public async Task<UserFlight?> Handle(GetUserFlightByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _userFlightRepository.GetByIdAsync(request.Id);

            return user;
        }
    }
}
