namespace Lez02_07_TaskCicli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Scrivere un sistema di gestione invitati alla propria festa.
             * L'inserimento avviene tramite console che prende in input (in due tempi diversi)
             * il nome ed il cognome.
             * 
             * All'uscita del programma verrà stampato l'elenco delle persone precedentemente
             * inserita, separate da virgola.
             */

            bool insAbi = true;
            string risultato = "";

            while (insAbi)
            {
                Console.WriteLine("Cosa vuoi fare?\n" +
                    "premi invio per un nuovo utente o digita Q per uscire");
                string? inputScelta = Console.ReadLine();

                if (inputScelta is not null && inputScelta.Equals("Q"))
                    insAbi = false;
                else
                {
                    Console.WriteLine("Inserisci il nome:");
                    string? inputNome = Console.ReadLine();

                    Console.WriteLine("Inserisci il cognome:");
                    string? inputCognome = Console.ReadLine();

                    risultato += inputNome + " " + inputCognome + ",";

                    Console.WriteLine("Operazione effettuata con successo!\n" +
                        "------------------------------------------------");
                }
            }

            Console.WriteLine(risultato);

        }
    }
}