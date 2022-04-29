﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Autenticacao_API.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Genero { get; set; }
        public string Role { get; set; }
        public bool? Lgpd { get; set; }
        public DateTime? Nascimento { get; set; }
    }
}
