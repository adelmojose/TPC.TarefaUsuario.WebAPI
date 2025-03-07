using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TPC.TarefaUsuario.API.Core.Data.Entity;

namespace TPC.TarefaUsuario.API.Controllers
{
  
[ApiController]
[Route("[controller]")]
public class SegurancaController : ControllerBase
{
    private readonly IConfiguration _config;

    public SegurancaController(IConfiguration config)
    {
        _config = config;
    }

        [HttpPost]
        public IActionResult Login([FromBody] UserAuth user)
        {
            bool resultado = ValidarUsuario(user);
            if (resultado)
            {
                var tokenString = GenerateTokenJwt(user);

                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
        private bool ValidarUsuario(UserAuth user)
        {
            if (user.Username == "admin" && user.Password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GenerateTokenJwt(UserAuth user)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Email, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


    }

}