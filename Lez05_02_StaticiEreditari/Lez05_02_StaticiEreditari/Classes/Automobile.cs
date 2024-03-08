using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez05_02_StaticiEreditari.Classes
{
    internal class Automobile : Giocattolo
    {
        public static int ContatoreAutomobile { get; private set; }
        public bool HasBatterie { get; set; } = false;

        public Automobile()
        {
            Console.WriteLine($"[AUTOMOBILE] costruttore invocato, sono il giocattolo {contatore}");
            ContatoreAutomobile++;
        }
    }
}
