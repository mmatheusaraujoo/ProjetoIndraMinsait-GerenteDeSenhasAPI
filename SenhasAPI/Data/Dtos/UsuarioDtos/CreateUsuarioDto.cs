using System.ComponentModel.DataAnnotations;

namespace SenhasAPI.Data.Dtos.UsuarioDtos
{
    public class CreateUsuarioDto
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        public CreateUsuarioDto(Guid id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
