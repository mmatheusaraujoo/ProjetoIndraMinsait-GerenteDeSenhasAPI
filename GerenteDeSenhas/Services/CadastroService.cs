using AutoMapper;
using FluentResults;
using GerenteDeSenhas.Data.Dtos;
using GerenteDeSenhas.Data.Request;
using GerenteDeSenhas.Migrations;
using GerenteDeSenhas.Models;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace GerenteDeSenhas.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<Guid>> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<Guid>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<Guid> usuarioIdentity = _mapper.Map<IdentityUser<Guid>>(usuario);
            Task<IdentityResult> identityResult = _userManager
                .CreateAsync(usuarioIdentity, createDto.Password);
            
            if (identityResult.Result.Succeeded)
            {
                string codigoDeAtivacao = _userManager
                    .GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                string encodedCode = HttpUtility.UrlEncode(codigoDeAtivacao);
                _emailService.EnviarEmail(
                    new[] { usuarioIdentity.Email },"Link de Ativação",
                    usuarioIdentity.Id,encodedCode);

                return Result.Ok().WithSuccess(codigoDeAtivacao);
            }
            return Result.Fail("Falha ao cadastrar usuário");

        }

        public Result AtivaContaUsusario(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(usuario => usuario.Id.Equals(request.UsuarioId));
            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if(identityResult.Succeeded)
            {
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Falha ao confirmar o usuário.");
            }
        }
    }
}
