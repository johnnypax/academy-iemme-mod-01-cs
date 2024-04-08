using Microsoft.EntityFrameworkCore;

namespace ASP_lerz09_contatti_CF.Models
{
    public class ContattoContext : DbContext
    {
        public ContattoContext(DbContextOptions<ContattoContext> options) : base(options) { }

        DbSet<Contatto> Contattos { get; set; }
    }
}
