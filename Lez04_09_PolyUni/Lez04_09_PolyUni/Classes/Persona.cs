using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_09_PolyUni.Classes
{
    public abstract class Persona
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }

        public virtual void stampaDettaglio()
        {
            Console.WriteLine($"[PERSONA] {Nome} {Cognome}");
        }
    }
}
