using GestaoUsuariosApi.Data;
using GestaoUsuariosApi.Models;
using MediatR;

namespace GestaoUsuariosApi.Features.Users.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.Usuarios.FindAsync(request.id);

            if (user is null) return false;

            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
