using Microsoft.EntityFrameworkCore;

namespace EF_CF_lez01_Migrations_Intro.Models
{
    public class ContattoContext : DbContext
    {
        public ContattoContext(DbContextOptions<ContattoContext> options) : base(options) { }

        public DbSet<Contatto> Contattos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contatto>()
                .HasIndex(e => e.CodiceFiscale).IsUnique();
        }
    }
}
