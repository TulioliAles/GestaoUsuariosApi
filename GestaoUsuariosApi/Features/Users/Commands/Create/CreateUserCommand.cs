using MediatR;

namespace GestaoUsuariosApi.Features.Users.Commands.Create
{
    public record CreateUserCommand(string Nome, string Sobrenome, string Email, string Cpf)
            : IRequest<int>;
}
