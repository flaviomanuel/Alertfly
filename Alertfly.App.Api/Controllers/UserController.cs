using Alertfly.App.Application.Commands.AddUser;
using Alertfly.App.Application.Commands.DeleteUser;
using Alertfly.App.Application.Commands.UpdateUser;
using Alertfly.App.Application.Queries.GetAllUsers;
using Alertfly.App.Application.Queries.GetUserById;
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

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddUserCommand command)
        {
            var id = await _mediator.Send(command);

            return Created("Add",new { id });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            
            await _mediator.Send(command);

            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);

            var user =  await _mediator.Send(query);

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetById()
        {
            var query = new GetAllUsersQuery();

            var users = await _mediator.Send(query);

            return Ok(users);
        }
    }
}
