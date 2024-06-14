using Alertfly.App.Application.Commands.AddUserFlight;
using Alertfly.App.Application.Commands.DeleteUserFlight;
using Alertfly.App.Application.Commands.UpdateUserAlertAt;
using Alertfly.App.Application.Queries.GetAllUserFlights;
using Alertfly.App.Application.Queries.GetAllUsers;
using Alertfly.App.Application.Queries.GetUserFlightById;
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


        [HttpDelete("DeleteUserFlight/{id}")]
        public async Task<IActionResult> DeleteUserFlight(Guid id)
        {
            var command = new DeleteUserFlightCommand(id);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserFlightByIdQuery(id);

            var userFlight = await _mediator.Send(query);

            return Ok(userFlight);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUserFlightsQuery();

            var userFlights = await _mediator.Send(query);

            return Ok(userFlights);
        }
    }
}
