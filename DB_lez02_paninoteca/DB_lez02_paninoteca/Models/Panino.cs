using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez02_paninoteca.Models
{
    internal class Panino
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public double Prezzo { get; set; }
        public bool IsVegan { get; set; }

        public override string ToString()
        {
            return $"{ID} {Nome} {Descrizione} {Prezzo} {(IsVegan ? "Vegano" : "Non vegano")}";
        }
    }
}
