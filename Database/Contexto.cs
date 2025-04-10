using Microsoft.EntityFrameworkCore;
using WebAPITickets.Models;

namespace WebAPITickets.Database
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Roles> Roles { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<Urgencia> Urgencias { get; set; }
            public DbSet<Importancia> Importancias { get; set; }
            public DbSet<Tiquete> Tiquetes { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Tabla Roles
                modelBuilder.Entity<Roles>().HasKey(r => r.ro_identificador);

                // Tabla Usuarios
                modelBuilder.Entity<Usuario>()
                    .HasKey(u => u.us_identificador);
                modelBuilder.Entity<Usuario>()
                    .HasOne<Roles>()
                    .WithMany()
                    .HasForeignKey(u => u.us_ro_identificador);

                // Tabla Categorias
                modelBuilder.Entity<Categoria>()
                    .HasKey(c => c.ca_identificador);

                // Tabla Urgencias
                modelBuilder.Entity<Urgencia>()
                    .HasKey(u => u.ur_identificador);

                // Tabla Importancias
                modelBuilder.Entity<Importancia>()
                    .HasKey(i => i.im_identificador);

                // Tabla Tiquetes
                modelBuilder.Entity<Tiquete>()
                    .HasKey(t => t.ti_identificador);
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
                modelBuilder.Entity<Tiquete>()
                    .HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey(t => t.ti_us_identificador);
            }
        }
    }
