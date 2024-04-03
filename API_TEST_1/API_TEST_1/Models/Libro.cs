using System.ComponentModel.DataAnnotations.Schema;

namespace API_TEST_1.Models
{
    [Table("Libro")]
    public class Libro
    {
        public int LibroId { get; set; }

        public string Codice { get; set; } = Guid.NewGuid().ToString();

        public string Titolo { get; set; } = null!;

        public string? Descrizione { get; set; }

        public string? Autore { get; set; }

        public decimal Prezzo { get; set; }

        public int? Quantita { get; set; }
    }
}
