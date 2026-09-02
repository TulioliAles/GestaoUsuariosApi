using GestaoUsuariosApi.Features.Users.Commands.Create;
using GestaoUsuariosApi.Features.Users.Queries.GetAllUsers;
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
    }
}
