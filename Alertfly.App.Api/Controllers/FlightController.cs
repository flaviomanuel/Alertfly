using Alertfly.App.Application.Commands.AddFlight;
using Alertfly.App.Application.Commands.UpdateFlight;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Alertfly.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddFlightCommand commad)
        {
            await _mediator.Send(commad);

            return Created();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateFlightCommand commad)
        {
            await _mediator.Send(commad);

            return Ok();
        }
    }
}
