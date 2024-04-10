using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CF_lez01_Migrations_Intro.Models
{
    [Table("Contacts")]
    public class Contatto
    {
        [Key]
        public int ContattoID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Nome { get; set; } = null!;

        [MaxLength(250)]
        public string? Cognome { get; set; }

        [Required]
        [MaxLength(150)]
        public string Telefono { get; set; } = null!;

        [MaxLength(150)]
        public string? Email { get; set; }

        [Required]
        public string CodiceFiscale { get; set; } = null!;
    }
}
