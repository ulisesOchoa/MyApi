using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApi.Application.Commands;
using MyApi.Application.Dto;
using MyApi.Application.Queries;
using MyApi.Application.Responses;

namespace MyApi.Presentation.Controllers
{
    public class UserController : ApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUser()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);

            return result.ToList();
        }

        [HttpGet("by-email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUserByEmail(string email)
        {
            var query = new GetUserByEmailQuery(email);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(new UpdateUserCommandWithId(id, command));

            return Ok();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);

            return Ok();
        }

    }
}
