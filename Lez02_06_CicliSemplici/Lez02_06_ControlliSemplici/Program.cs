namespace Lez02_06_ControlliSemplici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * indice
             * 
             * while(condizione){
             *      //Corpo da eseguire
             *      
             *      incremento
             * }
             */

            //int indice = 0;

            //while(indice < 5)
            //{
            //    Console.WriteLine("CIAO");

            //    indice++;
            //}

            //----------------------------------------

            //int indice = 0;
            //int max = 5;

            //while (indice < max)
            //{
            //    Console.WriteLine($"Sono all'indice {indice + 1}");

            //    indice++;
            //}

            //----------------------------------------

            //int i = 0;
            //int max = 0;

            //do
            //{
            //    Console.WriteLine($"Sono all'indice {i + 1}");

            //    i++;
            //} while (i < max);

            //---------------------------------------

            bool inserimentoAbilitato = true;

            while (inserimentoAbilitato)
            {
                Console.WriteLine("Inserisci il tuo nome o digita Q per uscire");
                string? inputUtente = Console.ReadLine();

                if (inputUtente is not null && inputUtente.Equals("Q"))
                    inserimentoAbilitato = false;
                else
                    Console.WriteLine($"Ciao {inputUtente}");
            }


            /*
             * Scrivere un sistema di gestione invitati alla propria festa.
             * L'inserimento avviene tramite console che prende in input (in due tempi diversi)
             * il nome ed il cognome.
             * 
             * All'uscita del programma verrà stampato l'elenco delle persone precedentemente
             * inserita, separate da virgola.
             */
        }
    }
}