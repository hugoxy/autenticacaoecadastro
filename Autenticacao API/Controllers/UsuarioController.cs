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
    public class UsuarioController : ControllerBase
    {
        private readonly DBAutenticacaoContext _context;

        public UsuarioController(DBAutenticacaoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListaUsuarios()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObterUsuarioPorID(int id)
        {
            if (id == 0)
            {
                return BadRequest("O ID é um campo obrigatorio");
            }
            var usuario = _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            return Ok(usuario);
        }

        [HttpPost]

        public IActionResult AdicionarUsuario(Usuario novoUsuario)
        {
            var usuario = new Usuario
            {
                Email = novoUsuario.Email,
                Nome = novoUsuario.Nome,
                Senha = novoUsuario.Senha,
                Materia = novoUsuario.Materia,
                Role = novoUsuario.Role,
            };

            _context.Usuarios.Add(usuario);

            _context.SaveChanges();

            return Ok("Usuários criado com sucesso");
        }

        [HttpPut]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {

            var usuarioBanco = _context.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault();

            if (usuarioBanco == null)
            {
                return NotFound("Usuário não encontrado");
            }

            usuarioBanco.Email = usuario.Email ?? usuarioBanco.Email;
            usuarioBanco.Senha = usuario.Senha ?? usuarioBanco.Senha;
            usuarioBanco.Materia = usuario.Materia ?? usuarioBanco.Materia;
            usuarioBanco.Role = usuario.Role ?? usuarioBanco.Role;


            _context.Usuarios.Update(usuarioBanco);

            _context.SaveChanges();

            return Ok("Usuário atualizado");
        }

        [HttpDelete("{id}")]

        public IActionResult DeletarUsuario(int id)
        {
            var usuarioBanco = _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();

            if (id == 0)
            {
                return NotFound("Usuário não encontrado");
            }

            _context.Usuarios.Remove(usuarioBanco);

            _context.SaveChanges();

            return Ok("Usuário removido com sucesso");

        }
    }
}
