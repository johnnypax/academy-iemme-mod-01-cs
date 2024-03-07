using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_03_TaskEredi.Classes
{
    internal class Automobile : Veicolo
    {
        public string? Targa { get; set; }
        public int NumPorte { get; set; }

        public override void metodoLocomozione()
        {
            Console.WriteLine("Va su strada");
        }

        public override string ToString()
        {
            return $"[Automobile] {Targa} {Telaio} {NumPorte}";
        }
    }
}
