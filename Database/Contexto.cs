using Microsoft.EntityFrameworkCore;
using WebAPITickets.Models;

namespace WebAPITickets.Database
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasKey(r => r.ro_identificador);
        }
    }
}
