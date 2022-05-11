using Autenticacao_API.DTOs.Autenticacao;
using Autenticacao_API.DTOs.Usuario;
using Autenticacao_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Autenticacao_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DBAutenticacaoContext _context;

        public UsuarioController(DBAutenticacaoContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrador,Professor")]
        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            IList<ListaUsuariosResponse> usuarios = await _context.Usuarios
                .Select(x => new ListaUsuariosResponse
                {
                    Email = x.Email,
                    Genero = x.Genero,
                    Id = x.Id,
                    Lgpd = x.Lgpd,
                    Nome = x.Nome,
                    Nascimento = x.Nascimento,
                    Role = x.Role
                }).ToListAsync();

            return Ok(usuarios);
        }

        [Authorize(Roles = "Administrador,Professor,Aluno")]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuarioPorID(int id)
        {
            if (id == 0)
                return BadRequest("O ID é um campo obrigatorio");

            BuscaUsuarioResponse usuario = await _context.Usuarios
                .Where(x => x.Id == id)
                .Select(x => new BuscaUsuarioResponse
                {
                    Email = x.Email,
                    Genero = x.Genero,
                    Lgpd = x.Lgpd,
                    Nome = x.Nome,
                    Nascimento = x.Nascimento,
                    Role = x.Role
                }).FirstOrDefaultAsync();

            if (usuario == null)
                return NotFound("Usuário não encontrado");

            return Ok(usuario);
        }

        [Authorize(Roles = "Administrador,Professor")]
        [HttpPost]
        public async Task<IActionResult> AdicionarUsuario(AdicionaUsuarioRequest novoUsuario)
        {
            var usuario = new Usuario
            {
                Email = novoUsuario.Email,
                Nome = novoUsuario.Nome,
                Senha = novoUsuario.Senha,
                Genero = novoUsuario.Genero,
                Role = novoUsuario.Role,
                Lgpd = novoUsuario.Lgpd,
                Nascimento = novoUsuario.Nascimento
            };

            Usuario usuarioBanco = await _context.Usuarios
                  .Where(x => x.Email == novoUsuario.Email)
                  .FirstOrDefaultAsync();

            if (usuarioBanco == null)
            {
                await _context.Usuarios.AddAsync(usuario);

                await _context.SaveChangesAsync();

                return Ok("Usuário criado com sucesso");
            }

            return Unauthorized("Usuário já cadastrado");

         
        }

        [Authorize(Roles = "Administrador,Professor,Aluno")]
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(AdicionaUsuarioRequest usuario, int id)
        {
            
            Usuario usuarioBanco = await _context.Usuarios
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (usuarioBanco == null)
                return NotFound("Usuário não encontrado");

            usuarioBanco.Email = usuario.Email ?? usuarioBanco.Email;
            usuarioBanco.Senha = usuario.Senha ?? usuarioBanco.Senha;
            usuarioBanco.Genero = usuario.Genero ?? usuarioBanco.Genero;
            usuarioBanco.Role = usuario.Role ?? usuarioBanco.Role;
            usuarioBanco.Lgpd = usuario.Lgpd ?? usuarioBanco.Lgpd;
            usuarioBanco.Nascimento = usuario.Nascimento ?? usuarioBanco.Nascimento;

            await _context.SaveChangesAsync();

            return Ok("Usuário atualizado");
        }

        [Authorize(Roles = "Administrador,Professor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            Usuario usuarioBanco = await _context.Usuarios
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (id == 0)
                return NotFound("Usuário não encontrado");

            _context.Remove(usuarioBanco);

            await _context.SaveChangesAsync();

            return Ok("Usuário removido com sucesso");
        }
    }
}
