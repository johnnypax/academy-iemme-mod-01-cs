using Microsoft.EntityFrameworkCore;

namespace ASP_lez03_EF_Manuale_Ferramenta.Models
{
    public class FerramentaContext : DbContext
    {
        public FerramentaContext(DbContextOptions<FerramentaContext> options) : base(options) { 
        
        }

        public DbSet<Prodotto> Prodotti { get; set; }
    }
}
