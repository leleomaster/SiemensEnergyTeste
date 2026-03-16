using Microsoft.EntityFrameworkCore;
using SiemensEnergyTeste.Domain.Entities;

namespace SiemensEnergyTeste.Persistence
{
    public class SiemensEnergyTesteContext : DbContext
    {
        public DbSet<LivroEntity> Livros { get; set; }
        public DbSet<AutorEntity> Autores { get; set; }
        public DbSet<GeneroEntity> Generos { get; set; }

        public SiemensEnergyTesteContext(DbContextOptions<SiemensEnergyTesteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroEntity>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Livros)
                .HasForeignKey(l => l.AutorId);

            modelBuilder.Entity<LivroEntity>()
                .HasOne(l => l.Genero)
                .WithMany(g => g.Livros)
                .HasForeignKey(l => l.GeneroId);
        }
    }
}
