using GerenteDeSenhas.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GerenteDeSenhas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroControler : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto createDto)
        {
            //TODO: CHAMAR O SERVIÇO
            return Ok();
        }
    }
}
