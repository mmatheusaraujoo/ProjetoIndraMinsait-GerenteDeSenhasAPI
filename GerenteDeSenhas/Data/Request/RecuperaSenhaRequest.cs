using System.ComponentModel.DataAnnotations;

namespace GerenteDeSenhas.Data.Request
{
    public class RecuperaSenhaRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string CodigoDeRecuperacao { get; set; }
    }
}
