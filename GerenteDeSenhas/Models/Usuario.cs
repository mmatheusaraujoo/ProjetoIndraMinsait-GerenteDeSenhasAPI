
using System.ComponentModel.DataAnnotations;

namespace GerenteDeSenhas.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        
        public string Email { get; set; }
    }
}
