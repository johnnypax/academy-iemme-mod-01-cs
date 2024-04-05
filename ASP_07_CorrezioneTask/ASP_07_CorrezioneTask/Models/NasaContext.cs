using Microsoft.EntityFrameworkCore;

namespace ASP_07_CorrezioneTask.Models
{
    public class NasaContext : DbContext
    {
        //... options costruttore per la configurazione di EF ...

        public DbSet<Oggetto> Oggettos { get; set; }
        public DbSet<Sistema> Sistemas { get; set; }
        public DbSet<OggettoSistema> OggettosSistemas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OggettoSistema>().HasKey(i => new { i.SistemaRIF, i.OggettoRIF });

            modelBuilder.Entity<OggettoSistema>()
                .HasOne(os => os.ogg)
                .WithMany(o => o.ElencoOggSis)
                .HasForeignKey(os => os.OggettoRIF);

            modelBuilder.Entity<OggettoSistema>()
               .HasOne(os => os.sis)
               .WithMany(s => s.ElencoOggSis)
               .HasForeignKey(os => os.SistemaRIF);
        }

    }
}
