using GerenteDeSenhas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenteDeSenhas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> otps) : base (otps)
        {
           
        }

        private DbSet<Senha> Senhas { get; set; }
        
    }

}
