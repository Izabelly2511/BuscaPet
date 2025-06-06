using System.ComponentModel.DataAnnotations;

namespace BuscaPet.Models
{
    public class Vacina
    {
        public int VacinaId { get; set; }
        public string TipoVacina { get; set; }
        public DateOnly DataAplicacao { get; set; }
        public DateOnly Validade { get; set; }
        public int PetId { get; set; }
        public Pet? Pet { get; set; }
    }
}
