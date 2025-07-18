﻿using System;

namespace BuscaPet.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }

    }
}
