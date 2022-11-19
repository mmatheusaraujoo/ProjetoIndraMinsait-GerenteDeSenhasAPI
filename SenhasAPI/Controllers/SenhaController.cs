using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SenhasAPI.Data.Dtos.SenhaDtos;
using SenhasAPI.Models;
using SenhasAPI.Services;
using System.Net;
using System.Net.Http.Headers;

namespace SenhasAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SenhaController : ControllerBase
    {
        private SenhaService _senhaService;

        public SenhaController(SenhaService senhaService)
        {
            _senhaService = senhaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListaSenhas([FromHeader] string Authorization) 
        {
            try
            {
                var senhas = await _senhaService.ListaSenhas(Authorization);
                if (senhas == null) { return NotFound(); }
                else { return Ok(senhas); }
            }
            catch (Exception e){return StatusCode(500,e.Message);}
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetornaSenha(Guid id, [FromHeader] string Authorization)
        {
            try
            {
                ReadSenhaDto senha = await _senhaService.RetornaSenha(id, Authorization);
                if (senha == null) { return NotFound(); }
                else { return Ok(senha); }
            }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> CriaNovaSenha([FromBody] CreateSenhaDto senhaDto, [FromHeader] string Authorization)
        {
            try
            { 
                ReadSenhaDto NovaSenhaDto = await _senhaService.CriaNovaSenha(senhaDto, Authorization);
                return CreatedAtAction(
                    nameof(RetornaSenha)
                    ,new
                    {
                        id = NovaSenhaDto.Id,
                        Authorization = Authorization
                    }
                    ,NovaSenhaDto) ;
            }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaSenha(Guid id, [FromHeader] string Authorization)
        {
            try
            {
                Result resultado = await _senhaService.DeletaSenha(id, Authorization);
                if (resultado.IsSuccess){return NoContent();}
                else{ return BadRequest(resultado.Errors.FirstOrDefault());}
            }
            catch (Exception e){return StatusCode(500, e.Message);}
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlteraSenha([FromBody] UpdateSenhaDto senhaDto, Guid id, [FromHeader] string Authorization)
        {
            try
            {
                Result resultado = await _senhaService.AlteraSenha(senhaDto,id, Authorization);
                if (resultado.IsSuccess){return NoContent();}
                else{return NotFound(resultado.Errors.FirstOrDefault());}
            }
            catch (Exception e){return StatusCode(500,e.Message);}
        }
    }
}
