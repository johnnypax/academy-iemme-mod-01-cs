using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_01_Interfacce.Classes
{
    internal class Pinguino : IAnimale
    {
        public bool Criniera { get; set; }

        public void tipoMovimento()
        {
            Console.WriteLine("Cammina");
        }

        public void versoEmesso()
        {
            Console.WriteLine("Boh");
        }
    }
}
