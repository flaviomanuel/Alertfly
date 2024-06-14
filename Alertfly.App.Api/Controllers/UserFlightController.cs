using Alertfly.App.Application.Commands.AddUserFlight;
using Alertfly.App.Application.Commands.UpdateUserAlertAt;
using Alertfly.App.Application.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alertfly.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFlightController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserFlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddUserFlightCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }

        [HttpPut("UpdateUserAlertAt")]
        public async Task<IActionResult> UpdateUserAlertAt(UpdateUserAlertAtCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
