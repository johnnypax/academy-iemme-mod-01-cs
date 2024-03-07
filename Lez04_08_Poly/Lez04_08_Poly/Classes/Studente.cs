using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_08_Poly.Classes
{
    internal class Studente : Persona
    {
        public string? Matricola { get; set; }

        public Studente(string? nome, string? cognome, string? matricola)
        {
            Nome = nome;
            Cognome = cognome;  
            Matricola = matricola;
        }
        public override void stampaDettaglio()
        {
            Console.WriteLine($"[STUDENTE] {Nome} {Cognome} {Matricola}");
        }

        public void stampaStudentePersonalizzato()
        {
            Console.WriteLine($"----------------{Matricola}---------------");
            Console.WriteLine($"Nome: {Nome} e Cognome: {Cognome}");
            Console.WriteLine($"---------------------------------------");
        }
    }
}
