using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_03_TaskEredi.Classes
{
    internal class Aereo : Veicolo
    {
        public override void metodoLocomozione()
        {
            Console.WriteLine("Vola");
        }
    }
}
