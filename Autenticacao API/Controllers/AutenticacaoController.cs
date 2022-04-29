using Autenticacao_API.DTOs;
using Autenticacao_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly DBAutenticacaoContext _context;
        private readonly IConfiguration _configuration;

        public AutenticacaoController(DBAutenticacaoContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] LoginRequest request)
        {
            Usuario usuario = await _context.Usuarios
                .Where(x => x.Email == request.Email && x.Senha == request.Senha)
                .FirstOrDefaultAsync();

            if (usuario == null)
                return Unauthorized("Login ou Senha Incorreto");

            string token = GenerateJwtToken(usuario);

            return Ok(token);
        }

        private string GenerateJwtToken(Usuario user)
        {
            // generate token that is valid for 8 hours
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            var claims = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim("Genero", user.Genero),
                new Claim("LGPD", user.Lgpd.ToString()),
                new Claim("Nascimento", user.Nascimento.ToString()),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
