using Autenticacao_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly DBAutenticacaoContext _context;

        public AutenticacaoController(DBAutenticacaoContext context)
        {
            _context = context;
        }

        [HttpGet("login")]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _context.Usuarios
                .Where(x => x.Email == email && x.Senha == senha)
                .FirstOrDefault();
            if (usuario == null)
            {
                return Unauthorized("Login ou Senha Incorreto");
            }
            return Ok("Login Realizado");
        }
    }
}
