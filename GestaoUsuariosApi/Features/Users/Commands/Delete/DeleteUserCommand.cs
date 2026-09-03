using MediatR;

namespace GestaoUsuariosApi.Features.Users.Commands.Delete
{
    public record DeleteUserCommand(int id) : IRequest<bool>;
}
