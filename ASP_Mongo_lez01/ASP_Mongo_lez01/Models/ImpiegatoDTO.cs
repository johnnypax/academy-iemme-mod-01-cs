using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ASP_Mongo_lez01.Models
{
    public class ImpiegatoDTO
    {
        [Required]
        [StringLength(100)]
        public string? Nom { get; set; }

        [Required]
        [StringLength(10)]
        public string? Mat { get; set; }

        [Required]
        [StringLength(100)]
        public string? Dip { get; set; }

        [Required]
        public DateTime Dat { get; set; }
    }
}
