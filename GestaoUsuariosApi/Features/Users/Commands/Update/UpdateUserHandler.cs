using GestaoUsuariosApi.Data;
using GestaoUsuariosApi.Models;
using MediatR;

namespace GestaoUsuariosApi.Features.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.Usuarios.FindAsync(request.id);

            if (user is null) return false;

            user.Nome = request.nome;
            user.Sobrenome = request.sobrenome;
            user.Email = request.email;
            user.Cpf = request.cpf;

            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
