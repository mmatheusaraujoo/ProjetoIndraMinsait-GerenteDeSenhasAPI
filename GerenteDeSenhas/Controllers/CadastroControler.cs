using FluentResults;
using GerenteDeSenhas.Data.Dtos;
using GerenteDeSenhas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenteDeSenhas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroControler : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroControler(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastraUsuario(createDto);
            if (resultado.IsSuccess) return Ok();
            return StatusCode(500);
        }
    }
}
