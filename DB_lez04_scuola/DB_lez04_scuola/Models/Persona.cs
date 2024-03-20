using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez04_scuola.Models
{
    internal abstract class Persona
    {
        public int Id { get; set; } 
        public string? Nominativo { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}
