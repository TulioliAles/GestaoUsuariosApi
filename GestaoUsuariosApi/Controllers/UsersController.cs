using GestaoUsuariosApi.Features.Users.Commands.Create;
using GestaoUsuariosApi.Features.Users.Commands.Delete;
using GestaoUsuariosApi.Features.Users.Commands.Update;
using GestaoUsuariosApi.Features.Users.Queries.GetAllUsers;
using GestaoUsuariosApi.Features.Users.Queries.GetByIdUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestaoUsuariosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var result = await _mediator.Send(new GetByIdUsersQuery(id));
            if (result is null) return NotFound("Registro não localizado!");
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result) return NotFound("Registro não localizado.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (!result) return NotFound("Registro não localizado.");

            return NoContent();
        }
    }
}
