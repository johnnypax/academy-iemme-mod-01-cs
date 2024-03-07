using Lez04_02_Recap.Classes;

namespace Lez04_02_Recap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] stuUno = { "Giovanni Pace", "12345", "PCAGNN" };
            string[] stuDue = { "Valeria Verdi", "12346", "VLRVRD" };
            string[] stuTre = { "Mario Rossi", "12347", "MRRRSS" };
 
            string[][] elenco = { stuUno, stuDue, stuTre };
            */

            Studente uno = new Studente("Giovanni Pace", 12345, "PCAGNN");
            Studente due = new Studente("Valeria Verdi", 12346, "VLRVRD");
            Studente tre = new Studente("Mario Rossi", 12347, "MRRRSS");
            //Studente quattro = new Studente();                        //NOn permesso
            //Studente cinque = new Studente();
            Studente sei = new Studente("Giovanni Pace", "PCAGNN");

            Studente[] elenco = { uno, due, tre, sei };

            // ------------------------------------------------- TASK
            /*
             * Creare un sistema di gestione veicoli:
             * 
             * All'inserimento di un nuovo veicolo mi sia permessa la scelta tra:
             * 1. Automobile
             * 2. Moto
             * 
             * Alla fine dell'inserimento delle caratteristiche del veicolo, stampare i suoi dettagli.
             * 
             * Libera scelta degli attributi
             */


        }
    }
}