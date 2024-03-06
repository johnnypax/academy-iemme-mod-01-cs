using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez03_08_Ereditarieta.Classes
{
    internal class Persona
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }

        public Persona()
        {

        }

        public Persona(string? nome, string? cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }   

        public virtual void stampaDettaglio()
        {
            Console.WriteLine($"{Nome} {Cognome}");
        }
    }
}
