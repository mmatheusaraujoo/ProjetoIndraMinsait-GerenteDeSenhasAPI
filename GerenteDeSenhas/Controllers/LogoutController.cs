using FluentResults;
using GerenteDeSenhas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenteDeSenhas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result resultado = _logoutService.DeslogaUsuario();
            
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
