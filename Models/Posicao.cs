namespace BuscaPet.Models
{
    public class Posicao
    {
        public int PosicaoId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataHora { get; set; }
    }
}
