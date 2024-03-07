using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_03_TaskEredi.Classes
{
    internal class Moto : Veicolo
    {
        public bool HasPortapacchi { get; set; }

        public override string ToString()
        {
            return $"[Moto] {Targa} {Telaio} {HasPortapacchi}";
        }
    }
}
