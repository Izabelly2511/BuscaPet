namespace BuscaPet.Models
{
    public class Alerta
    {
        public int AlertaId { get; set; }
        public string Tipo { get; set; } 
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
