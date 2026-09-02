using GestaoUsuariosApi.Data;
using GestaoUsuariosApi.Models;
using MediatR;

namespace GestaoUsuariosApi.Features.Users.Queries.GetByIdUsers
{
    public class GetByIdUsersHandler : IRequestHandler<GetByIdUsersQuery, User>
    {
        private readonly AppDbContext _context;

        public GetByIdUsersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetByIdUsersQuery request, CancellationToken cancellationToken)
        {
            User user = await _context.Usuarios.FindAsync(request.id);

            return user;
        }
    }
}
