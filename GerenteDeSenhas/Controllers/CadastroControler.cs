using FluentResults;
using GerenteDeSenhas.Data.Dtos;
using GerenteDeSenhas.Data.Request;
using GerenteDeSenhas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenteDeSenhas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastraUsuario(createDto);
            if (resultado.IsSuccess) return Ok(resultado.Successes.FirstOrDefault());
            return StatusCode(500);
        }

        [HttpGet("/ativacao")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaContaUsusario(request);
            if (resultado.IsSuccess) return Ok(resultado.Successes.FirstOrDefault());
            return StatusCode(500);
        }
    }
}
