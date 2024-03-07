using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_03_TaskEredi.Classes
{
    internal class Automobile : Veicolo
    {
        public int NumPorte { get; set; }

        public override string ToString()
        {
            return $"[Automobile] {Targa} {Telaio} {NumPorte}";
        }
    }
}
