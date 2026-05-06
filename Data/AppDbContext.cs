using Cp2FilmesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cp2FilmesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()
                .Property(f => f.NotaImdb)
                .HasPrecision(3, 1);

            base.OnModelCreating(modelBuilder);
        }
    }
}