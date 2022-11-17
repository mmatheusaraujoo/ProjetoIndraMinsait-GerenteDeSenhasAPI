using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace GerenteDeSenhas.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<Guid>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<Guid>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result DeslogaUsuario()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();

            if (resultadoIdentity.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Logout Falhou.");
            }
        }
    }
}
