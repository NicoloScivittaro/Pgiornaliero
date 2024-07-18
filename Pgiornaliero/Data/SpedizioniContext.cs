using Microsoft.EntityFrameworkCore;
using SpedizioniApp.Models;

namespace SpedizioniApp.Data
{
    public class SpedizioniContext : DbContext
    {
        public SpedizioniContext(DbContextOptions<SpedizioniContext> options) : base(options) { }

        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Spedizione> Spedizioni { get; set; }
        public DbSet<AggiornamentoSpedizione> AggiornamentiSpedizioni { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clienti");
            modelBuilder.Entity<Spedizione>().ToTable("Spedizioni");
            modelBuilder.Entity<AggiornamentoSpedizione>().ToTable("AggiornamentiSpedizioni");
        }
    }
}