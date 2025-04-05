using Microsoft.EntityFrameworkCore;
using WebAPITickets.Models;

namespace WebAPITickets.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Creador)
                .WithMany(u => u.TicketsCreados)
                .HasForeignKey(t => t.CreadorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.AsignadoA)
                .WithMany(u => u.TicketsAsignados)
                .HasForeignKey(t => t.AsignadoAId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
