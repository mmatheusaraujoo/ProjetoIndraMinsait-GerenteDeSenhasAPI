using FluentResults;
using GerenteDeSenhas.Data.Request;
using GerenteDeSenhas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenteDeSenhas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);
            if (resultado.IsSuccess) 
            {
                return Ok(resultado.Successes.FirstOrDefault());
            }
            else { return Unauthorized(resultado.Errors.FirstOrDefault()); }
            
        }

        [HttpPost("/solicita-recupera-senha")]
        public IActionResult SolicitaRecuperaSenhaUsuario(SolicitaRecuperaSenhaRequest request)
        {
            Result resultado = _loginService.SolicitaRecuperaSenhaUsuario(request);
            if (resultado.IsSuccess) 
            {
                return Ok(resultado.Successes.FirstOrDefault());
            }
            else
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }

        }

        [HttpPost("/recupera-senha")]
        public IActionResult RecuperaSenhaUsuario(RecuperaSenhaRequest request)
        {
            Result resultado = _loginService.RecuperaSenhaUsuario(request);
            if (resultado.IsSuccess)
            {
                return Ok(resultado.Successes.FirstOrDefault());
            }
            else
            {
                return Unauthorized(resultado.Errors.FirstOrDefault());
            }

        }


    }

}
 