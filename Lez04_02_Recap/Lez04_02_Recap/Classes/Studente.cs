using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_02_Recap.Classes
{
    internal class Studente
    {
        public string? Nominativo { get; set; }
        public int Matricola { get; set; }
        public string? CodFis { get; set; }

        private Studente()
        {

        }

        public Studente(string? nominativo, string? codFis)
        {
            Nominativo = nominativo;
            CodFis = codFis;
        }

        public Studente(string? nominativo, int matricola, string? codFis)
        {
            Nominativo = nominativo;
            Matricola = matricola;
            CodFis = codFis;
        }
    }
}
