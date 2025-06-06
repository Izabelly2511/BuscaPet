using System;

namespace BuscaPet.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Especie { get; set; }
        public string Observacao { get; set; }
        public string Raca { get; set; }

        public int? TagId { get; set; }

    }
}
