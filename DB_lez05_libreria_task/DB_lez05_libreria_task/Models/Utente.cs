using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez05_libreria_task.Models
{
    internal class Utente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email { get; set; }
        public string? Codice { get; set; }

        //Non serve SOFT DELETE

        public List<Prestito> ElencoPrestiti { get; set; } = new List<Prestito>();

    }
}
