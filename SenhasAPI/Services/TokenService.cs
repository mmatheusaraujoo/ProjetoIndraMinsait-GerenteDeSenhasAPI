
using FluentResults;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SenhasAPI.Models;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SenhasAPI.Services
{
    public class TokenService
    {

        private Dictionary<string, string> ExtrairDados(string autorizacao)
        {

            Dictionary<string, string> tokenDados = new Dictionary<string, string>();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string tokenTratado = TratarToken(autorizacao);

            JwtSecurityToken jwtSecurityToken = handler.ReadJwtToken(tokenTratado);
            List<System.Security.Claims.Claim> claims = jwtSecurityToken.Claims.ToList();

            foreach (var claim in claims)
            {
                tokenDados.Add(claim.Type, claim.Value);
            }
            return tokenDados;
        }
        public Usuario CriarUsuarioUsandoToken(string token)
        {
            Guid usuarioId = ExtrairIdUsuario(token);
            string usuarioUsername = ExtrairUsername(token);

            Usuario NovoUsuario = new Usuario(usuarioId,usuarioUsername);
            return NovoUsuario;

        }
        public Guid ExtrairIdUsuario(string token)
        {
            try
            {
                Dictionary<string, string> dados = ExtrairDados(token);
                Guid id = Guid.Empty;
                foreach (KeyValuePair<string, string> dado in dados)
                {
                    if (dado.Key.Equals("id"))
                    {
                        id = Guid.Parse(dado.Value);
                    }
                }
                return id; 
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public string ExtrairUsername(string token)
        {
            Dictionary<string, string> dados = ExtrairDados(token);
            foreach (KeyValuePair<string, string> dado in dados)
            {
                if (dado.Key.Equals("username"))
                {
                    
                    return dado.Value;
                }
            }
            return null;
        }



        private string TratarToken (string token)
        {
            string[] tokenSeparado = token.Split(' ');
            string tokenTratado = tokenSeparado[tokenSeparado.Length - 1];

            return tokenTratado;
        }
    }
}
