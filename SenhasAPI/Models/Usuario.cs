using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace SenhasAPI.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
 
        public virtual List<Senha> Senhas { get; set; } = new List<Senha>();

        public Usuario(Guid id, string username, List<Senha> senhas)
        {
            Id = id;
            Username = username;
            Senhas = senhas;
        }

        public Usuario(Guid id,string username)
        {
            Id = id;
            Username = username;
            Senhas = new List<Senha>();
        }
    }
}
