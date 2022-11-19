using FluentResults;
using GerenteDeSenhas.Data.Request;
using GerenteDeSenhas.Models;
using Microsoft.AspNetCore.Identity;

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

        public Result SolicitaRecuperaSenhaUsuario(SolicitaRecuperaSenhaRequest request)
        {
            IdentityUser<Guid> identityUser = RecuperaUsuarioPorEmail(request.Email);
            if (identityUser != null)
            {
                string codigoDeRecuperacao = _signInManager
                    .UserManager
                    .GeneratePasswordResetTokenAsync(identityUser)
                    .Result;
                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }
            return Result.Fail("Falha ao solicitar recuperação de senha");
        }


        public Result RecuperaSenhaUsuario(RecuperaSenhaRequest request)
        {
            IdentityUser<Guid> identityUser = RecuperaUsuarioPorEmail(request.Email);
            IdentityResult identityResult = _signInManager
                .UserManager
                .ResetPasswordAsync(identityUser,request.CodigoDeRecuperacao, request.Password)
                .Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
            }
            else
            {
                return Result.Fail("Erro ao redefinir senha.");
            }
        }

        private IdentityUser<Guid> RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedEmail.Equals(email.ToUpper()));
        }
    }
}
