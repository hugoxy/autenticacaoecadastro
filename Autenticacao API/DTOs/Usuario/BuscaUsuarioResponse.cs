using System;

namespace Autenticacao_API.DTOs.Usuario
{
    public class BuscaUsuarioResponse
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public string Role { get; set; }
        public bool? Lgpd { get; set; }
        public DateTime? Nascimento { get; set; }
    }
}
