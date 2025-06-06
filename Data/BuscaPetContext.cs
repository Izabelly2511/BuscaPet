using BuscaPet.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscaPet.Data
{
    public class BuscaPetContext : DbContext
    {
        public BuscaPetContext(DbContextOptions<BuscaPetContext> options) : base(options)
        {
        }

        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Alimentacao> Alimentacoes { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }
        public DbSet<Posicao> Posicoes { get; set; } 
    }
}
