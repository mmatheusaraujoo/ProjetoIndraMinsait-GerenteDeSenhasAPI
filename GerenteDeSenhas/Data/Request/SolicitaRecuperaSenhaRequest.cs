using System.ComponentModel.DataAnnotations;

namespace GerenteDeSenhas.Data.Request
{
    public class SolicitaRecuperaSenhaRequest
    {
       [Required]
       [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
