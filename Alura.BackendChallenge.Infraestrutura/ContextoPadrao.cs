using Alura.BackendChallenge.Dominio.Objetos.VideoObj;
using Alura.BackendChallenge.Infraestrutura.Mapeadores.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Alura.BackendChallenge.Infraestrutura
{
    public class ContextoPadrao : DbContext
    {
        public ContextoPadrao(DbContextOptions<ContextoPadrao> opcoes) : base(opcoes)
        {

        }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VideoMap());
        }
    }
}
