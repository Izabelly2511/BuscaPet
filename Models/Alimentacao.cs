using System.ComponentModel.DataAnnotations;

namespace BuscaPet.Models
{
    public class Alimentacao
    {
        public int AlimentacaoId { get; set; }
        public string Tipo { get; set; }
        public DateTime DataAlimentacao { get; set; }
        public string Observacao { get; set; }
        public int PetId { get; set; }
        public Pet? Pet { get; set; }

    }
}
