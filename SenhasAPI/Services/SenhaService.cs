using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenhasAPI.Data;
using SenhasAPI.Data.Dtos.SenhaDtos;
using SenhasAPI.Models;
using System.Threading.Tasks;

namespace SenhasAPI.Services
{
    public class SenhaService
    {
        private SenhaDbContext _dbContext;
        private IMapper _mapper;
        private TokenService _tokenService;

        public SenhaService(SenhaDbContext dbContext, IMapper mapper, TokenService tokenService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        internal async Task<Result> AlteraSenha(UpdateSenhaDto senhaDto, Guid senhaId, string autorizacao)
        {
            try
            {
                Senha senha = await RetornaSenhaPorId(senhaId, autorizacao);
                if(senha == null)
                {
                    return Result.Fail("Senha não encontrada.");
                }
                senha = _mapper.Map<Senha>(senhaDto);
                await _dbContext.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception){ throw; }

        }


        internal async Task<ReadSenhaDto> CriaNovaSenha(CreateSenhaDto senhaDto, string autorizacao)
        {
            try
            {
                Senha novaSenha;
                Usuario usuario = await checarAutenticacao(autorizacao);
                if (usuario == null)
                {
                    var novoUsuario = _tokenService.CriarUsuarioUsandoToken(autorizacao);
                    await _dbContext.Usuarios.AddAsync(novoUsuario);
                    novaSenha = _mapper.Map<Senha>(senhaDto);
                    novaSenha.UsuarioId = novoUsuario.Id;
                    
                }
                else 
                { 
                    novaSenha = _mapper.Map<Senha>(senhaDto);
                    novaSenha.UsuarioId = usuario.Id;
                }

                await _dbContext.Senhas.AddAsync(novaSenha);
                await _dbContext.SaveChangesAsync();
                ReadSenhaDto novaSenhaDto = _mapper.Map<ReadSenhaDto>(novaSenha);
                return novaSenhaDto;
            }
            catch (Exception) { throw; }

        }

        public async Task<Result> DeletaSenha(Guid senhaId, string autorizacao)
        {
            try
            {
                Senha senha = _mapper.Map<Senha>(RetornaSenhaPorId(senhaId,autorizacao));
                if (senha == null)
                {
                    return Result.Fail("Senha não encontrada.");
                }
                _dbContext.Senhas.Remove(senha);
                await _dbContext.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception) { throw; }
        }

        internal async Task<List<ReadSenhaDto>> ListaSenhas(string autorizacao)
        {
            try
            {
                Usuario? usuario = await checarAutenticacao(autorizacao);
                if (usuario == null)
                {
                    throw new ArgumentNullException("Não foi possivel encontrar o usuário");
                }
                List<Senha> senhas = await _dbContext.Senhas.Where(senha => senha.UsuarioId == usuario.Id).ToListAsync();
                List<ReadSenhaDto> senhasListadas = _mapper.Map<List<ReadSenhaDto>>(senhas);
                return senhasListadas;
            }
            catch (Exception) { throw; }
        }


        public async Task<ReadSenhaDto> RetornaSenha(Guid id, string authorization)
        {
            try
            {
                Senha? senha = await RetornaSenhaPorId(id, authorization);
                ReadSenhaDto senhaDto = _mapper.Map<ReadSenhaDto>(senha);
                return senhaDto;
            }
            catch (Exception) { throw; }
        }

        private async Task<Usuario>? checarAutenticacao(string autorizacao)
        {
            try
            {
                Guid? usuarioId = _tokenService.ExtrairIdUsuario(autorizacao);
                Usuario? usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id.Equals(usuarioId));

                return usuario;
            }
            catch (Exception){throw;}
        }

        private async Task<Senha>? RetornaSenhaPorId(Guid senhaId, string autorizacao)
        {
            try
            {
                Usuario? usuario = await checarAutenticacao(autorizacao);
                if (usuario == null)
                {
                    throw new ArgumentNullException("Não foi possivel encontrar o usuário");
                }
                Senha? senha = await _dbContext.Senhas.FirstOrDefaultAsync(senha => senha.Id.Equals(senhaId));
                return senha;
            }
            catch (Exception) { throw; }
        }
    }
}
