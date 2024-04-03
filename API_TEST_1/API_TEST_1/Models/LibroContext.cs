using Microsoft.EntityFrameworkCore;

namespace API_TEST_1.Models
{
    public class LibroContext : DbContext
    {
        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libri { get; set; }
    }
}
