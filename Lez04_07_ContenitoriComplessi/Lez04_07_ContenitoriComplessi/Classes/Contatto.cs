using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_07_ContenitoriComplessi.Classes
{
    internal class Contatto
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public override string ToString()
        {
            return $"{Nome} {Cognome} {Email} {Telefono}";
        }
    }
}
