using Microsoft.EntityFrameworkCore;
using SenhasAPI.Models;

namespace SenhasAPI.Data
{
    public class SenhaDbContext : DbContext
    {
        public SenhaDbContext(DbContextOptions<SenhaDbContext> opts) : base (opts)
        {

        }

        public DbSet<Senha> Senhas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
