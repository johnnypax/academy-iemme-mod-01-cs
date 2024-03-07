using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_09_PolyUni.Classes
{
    internal class Docente : Persona
    {
        public string? Dipartimento { get; set; }
        public string? Materia { get; set; }

        public Docente(string? nome, string? cognome, string? dipartimento, string? materia)
        {
            Nome = nome;
            Cognome = cognome;
            Dipartimento = dipartimento;
            Materia = materia;
        }
        public override void stampaDettaglio()
        {
            Console.WriteLine($"[DOCENTE] {Nome} {Cognome} {Dipartimento} {Materia}");
        }
        public void stampaDocentePersonalizzato()
        {
            Console.WriteLine($"+---------------DOCENTE--------------+");
            Console.WriteLine($"Nome: {Nome} e Cognome: {Cognome}");
            Console.WriteLine($"Materia: {Materia} e Dipartimento: {Dipartimento}");
            Console.WriteLine($"+-------------------------------------+");
        }
    }
}
