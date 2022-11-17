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
        
    
    }

}
 