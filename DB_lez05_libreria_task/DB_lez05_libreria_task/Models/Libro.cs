using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez05_libreria_task.Models
{
    internal class Libro
    {
        //public const string VALORE = "CIAO"; 

        public int Id { get; set; }
        public string? Titolo { get; set; }
        public int Anno { get; set; }
        public bool Disp { get; set; }
        public string? Isbn { get; set; }
        public List<Prestito> ElencoPrestiti { get; set; } = new List<Prestito>();
    }
}
