using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez05_04_ProvaCSV.Classes
{
    internal class Persona
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? CodFis { get; set; }

        public Persona(string? nome, string? cognome, string? codFis)
        {
            Nome = nome;
            Cognome = cognome;
            CodFis = codFis;
        }

        public override string ToString()
        {
            return $"[PERSONA] {Nome} {Cognome} {CodFis}";
        }

        public string esportaCsv()
        {
            return $"{Nome};{Cognome};{CodFis}";
        }
    }
}
