using MediatR;

namespace GestaoUsuariosApi.Features.Users.Commands.Update
{
    public record UpdateUserCommand(int id, string nome, string sobrenome, string email, string cpf) 
        : IRequest<bool>;
}
