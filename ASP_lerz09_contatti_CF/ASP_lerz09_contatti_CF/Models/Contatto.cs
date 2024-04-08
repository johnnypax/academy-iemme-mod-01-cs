using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_lerz09_contatti_CF.Models
{
    [Table("Contatti")]
    public class Contatto
    {
        [Key]
        public int ContattoID { get; set; }

        [MaxLength(250)]
        [Required]
        public string Nome { get; set; } = null!;

        [MaxLength(250)]
        public string? Cognome { get; set; }

        [MaxLength(250)]
        [Required]
        public string Telefono { get; set; } = null!;

        [MaxLength(250)]
        public string? Email { get; set; }   

        public string? Indirizzo { get; set; }
        
    }
}
