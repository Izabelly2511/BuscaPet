namespace BuscaPet.Models
{
    public class UsuarioPet
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public string TipoRelacao { get; set; }
    }
}
