using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez05_02_StaticiEreditari.Classes
{
    internal abstract class Giocattolo
    {
        public string? Materiale { get; set; }
        public int EtaMinima { get; set; } = 3;

        //public static int Contatore { get; private set; } = 0;

        protected static int contatore = 0;

        public static int Contatore
        {
            get { return contatore; }
        }


        public Giocattolo()
        {
            Console.WriteLine("[GIOCATTOLO] costruttore invocato");
            contatore++;
        }
    }
}
