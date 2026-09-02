using GestaoUsuariosApi.Models;
using MediatR;

namespace GestaoUsuariosApi.Features.Users.Queries.GetByIdUsers
{
    public record GetByIdUsersQuery(int id) : IRequest<User>;
}
