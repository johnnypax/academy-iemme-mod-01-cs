using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_09_PolyUni.Classes
{
    internal class Universita
    {
        public string? Nome { get; set; }
        protected List<Persona> elenco { get; set; } = new List<Persona>();

        public void aggiungi(Persona per)
        {
            elenco.Add(per);
        }

        public void elencoStudenti()
        {
            Console.WriteLine($"------------------ UNIVERSITA: {Nome}");
            for (int i = 0; i < elenco.Count; i++)
            {
                elenco[i].stampaDettaglio();
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}
