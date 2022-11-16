using System.ComponentModel.DataAnnotations;

namespace GerenteDeSenhas.Models
{
    public class Senha
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Valor { get; set; }
        [Required]
        public string TipoDeCriptografia { get; set; }
    }
}
