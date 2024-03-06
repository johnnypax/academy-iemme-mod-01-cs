using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez03_07_InfoHidingIncapsulamento.Classes
{
    internal class Bicicletta
    {
        public string? Marca { get; set; }
        public string? Tipo { get; set; }
        public bool HasCampanello { get; set; } = false;

        // Bicicletta()
        public Bicicletta()
        {
            Console.WriteLine("Costruttore di default invocato!");
        }

        // Bicicletta(string, string, bool)
        public Bicicletta(string? marca, string? tipo, bool hasCampanello)
        {
            this.Marca = marca;
            this.Tipo = tipo;
            this.HasCampanello = hasCampanello;
            Console.WriteLine("Costruttore con tre parametri!");
        }

        // Bicicletta(bool, string)
        public Bicicletta(bool hasCampanello, string? tipo)
        {
            Tipo = tipo;
            HasCampanello = hasCampanello;
            Console.WriteLine("Costruttore con due parametri!");
        }
    }
}
