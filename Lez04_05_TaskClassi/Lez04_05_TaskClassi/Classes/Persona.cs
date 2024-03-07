using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_05_TaskClassi.Classes
{
    internal class Persona
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public CartaIdentita? Identita { get; set; }
        public CodiceFiscale? Fiscale { get; set; }

        public override string ToString()
        {
            return $"[PERSONA] {Nome} {Cognome} {Identita} {Fiscale}";
        }
    }
}
