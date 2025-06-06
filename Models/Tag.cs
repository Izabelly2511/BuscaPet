using Microsoft.EntityFrameworkCore;

namespace BuscaPet.Models
{
    public class Tag
    {
        public int TagId { get; set; } 
        public string CodigoUnico { get; set; } 

        public string Localizacao { get; set; } = string.Empty;
        public string QrCode { get; set; } = string.Empty;

        public int? PetId { get; set; }
        public Pet? Pet { get; set; }

    }
}
