using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez03_07_InfoHidingIncapsulamento.Classes
{
    internal class Moto
    {
        private string? modello;
        private int? cilindrata;

        //void setCilindrata(int)
        public void setCilindrata(int valCil)
        {
            if (valCil >= 0)
                cilindrata = valCil;
            else
                Console.WriteLine("Errore, cilindrata non consentita");
        }

        public int? getCilindrata()
        {
            return cilindrata;
        }
    }
}
