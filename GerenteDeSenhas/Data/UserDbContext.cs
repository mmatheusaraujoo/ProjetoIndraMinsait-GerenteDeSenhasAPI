using GerenteDeSenhas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenteDeSenhas.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<Guid>,IdentityRole<Guid>, Guid>
    {
        public UserDbContext(DbContextOptions<UserDbContext> otps) : base (otps)
        {
           
        }

        private DbSet<Usuario> Usuarios { get; set; }
        
    }

}
