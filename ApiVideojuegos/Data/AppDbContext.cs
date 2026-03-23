using ApiVideojuegos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiVideojuegos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Videojuego> Videojuegos => Set<Videojuego>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorias");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(x => x.Activo).IsRequired();
            });

            modelBuilder.Entity<Videojuego>(entity =>
            {
                entity.ToTable("Videojuegos");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(x => x.Descripcion).IsRequired().HasMaxLength(250);
                entity.Property(x => x.Activo).IsRequired();

                entity.HasOne(x => x.Categoria)
                    .WithMany(c => c.Videojuegos)
                    .HasForeignKey(x => x.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}