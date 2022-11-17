using System.ComponentModel.DataAnnotations;

namespace GerenteDeSenhas.Data.Request
{
    public class AtivaContaRequest
    {
        [Required]
        public string CodigoDeAtivacao { get; set; }
        
        [Required]
        public Guid UsuarioId { get; set; }
    }
}
