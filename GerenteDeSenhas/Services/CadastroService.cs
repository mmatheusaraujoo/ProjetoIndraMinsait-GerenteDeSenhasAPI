using AutoMapper;
using FluentResults;
using GerenteDeSenhas.Data.Dtos;
using GerenteDeSenhas.Migrations;
using GerenteDeSenhas.Models;
using Microsoft.AspNetCore.Identity;

namespace GerenteDeSenhas.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<Guid>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<Guid>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<Guid> usuarioIdentity = _mapper.Map<IdentityUser<Guid>>(usuario);
            Task<IdentityResult> identityResult = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            if (identityResult.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");

        }
    }
}
