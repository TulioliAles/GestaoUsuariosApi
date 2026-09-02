using GestaoUsuariosApi.Data;
using GestaoUsuariosApi.Models;
using MediatR;

namespace GestaoUsuariosApi.Features.Users.Commands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                Email = request.Email,
                Cpf = request.Cpf
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
