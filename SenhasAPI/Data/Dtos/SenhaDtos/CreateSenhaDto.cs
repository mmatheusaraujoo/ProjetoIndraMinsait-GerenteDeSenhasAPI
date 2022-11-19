using System.ComponentModel.DataAnnotations;

namespace SenhasAPI.Data.Dtos.SenhaDtos
{
    public class CreateSenhaDto
    {
        [Required]
        [MinLength(2)]
        public string Descricao { get; set; }

        [Required]
        [MinLength(4)]
        public string Login { get; set;}

        [Required]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Valor { get; set; }

        public CreateSenhaDto(string descricao, string login, string valor)
        {
            Descricao = descricao;
            Login = login;
            Valor = valor;
        }
    }
}
