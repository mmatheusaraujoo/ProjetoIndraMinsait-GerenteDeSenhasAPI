using FluentResults;
using GerenteDeSenhas.Data.Request;
using GerenteDeSenhas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GerenteDeSenhas.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<Guid>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<Guid>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            Task<SignInResult> resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                IdentityUser<Guid> identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName
                    .Equals(request.Username.ToUpper()));

                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
                
            }
            return Result.Fail("Não foi possível realizar o login. Login Falhou!");
        }
    }
}
