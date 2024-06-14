using Alertfly.App.Application.Commands.AddFlight;
using Alertfly.App.Application.Commands.DeleteFlight;
using Alertfly.App.Application.Commands.UpdateFlight;
using Alertfly.App.Application.Queries.GetAllFlights;
using Alertfly.App.Application.Queries.GetFlightById;
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
        public async Task<IActionResult> Add(AddFlightCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateFlightCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command  = new DeleteFlightCommand(id);

            await _mediator.Send(command);

            return Ok();
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetFlightByIdQuery(id);

           var flight = await _mediator.Send(command);

            return Ok(flight);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllFlightsQuery();

            var flights = await _mediator.Send(query);

            return Ok(flights);
        }
    }
}
