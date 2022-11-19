using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SenhasAPI.Models
{
    public class Senha
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Login { get; set; }

        [Required]
        [MinLength(2)]
        public string Descricao { get; set; }

        [Required]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Valor { get; set; }
        
        [Required]
        public DateTime DataDeCriacao { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        
        [Required]
        [ForeignKey("Usuario")]
        public Guid UsuarioId{ get; set; }
    }
}
