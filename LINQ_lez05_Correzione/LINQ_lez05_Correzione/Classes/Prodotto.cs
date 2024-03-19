using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_lez05_Correzione.Classes
{
    internal class Prodotto
    {
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public float Prezzo { get; set; } = 0;
        public string? Categoria { get; set; }
        public int Quantita { get; set; }
    }
}
