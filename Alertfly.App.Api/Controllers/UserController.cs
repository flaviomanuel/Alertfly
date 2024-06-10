using Alertfly.App.Application.Commands.AddUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alertfly.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] AddUserCommand command)
        {
            var id = await _mediator.Send(command);

            return Created("Add",new { id });
        }
    }
}
