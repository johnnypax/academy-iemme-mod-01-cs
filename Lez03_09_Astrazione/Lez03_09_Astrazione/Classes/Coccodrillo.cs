using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lez03_09_Astrazione.Classes
{
    internal class Coccodrillo : Animale
    {
        public override void versoEmesso()
        {
            Console.WriteLine("Non c'è nessuno che lo sa!");
        }
    }
}
