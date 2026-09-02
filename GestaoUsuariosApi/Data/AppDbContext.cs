using GestaoUsuariosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoUsuariosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {            
        }

        public DbSet<User> Usuarios { get; set; }
    }
}
