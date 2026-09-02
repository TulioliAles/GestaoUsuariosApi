using GestaoUsuariosApi.Models;
using MediatR;

namespace GestaoUsuariosApi.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<List<User>>;
}
