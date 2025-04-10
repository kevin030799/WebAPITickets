using Microsoft.EntityFrameworkCore;
using WebAPITickets.Models;

namespace SoporteApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Urgencia> Urgencias { get; set; }
        public DbSet<Importancia> Importancias { get; set; }
        public DbSet<Tiquete> Tiquetes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne<Roles>()
                .WithMany()
                .HasForeignKey(u => u.us_ro_identificador);

            modelBuilder.Entity<Tiquete>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(t => t.ti_us_identificador);

            modelBuilder.Entity<Tiquete>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(t => t.ti_ca_identificador);

            modelBuilder.Entity<Tiquete>()
                .HasOne<Urgencia>()
                .WithMany()
                .HasForeignKey(t => t.ti_ur_identificador);

            modelBuilder.Entity<Tiquete>()
                .HasOne<Importancia>()
                .WithMany()
                .HasForeignKey(t => t.ti_im_identificador);
        }
    }
}

