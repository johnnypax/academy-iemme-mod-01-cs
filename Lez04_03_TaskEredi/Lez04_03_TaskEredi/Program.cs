using Lez04_03_TaskEredi.Classes;

namespace Lez04_03_TaskEredi
{
    internal class Program
    {
        static void Main(string[] args)
        {
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


            bool insAbi = true;

            while (insAbi)
            {
                Console.WriteLine("Decidi cosa inserire\n1. Automobile\n 2. Moto\nQ. Uscire");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Inserire targa:");
                            string? inTarga = Console.ReadLine();

                            Console.WriteLine("Inserire telaio:");
                            int inTelaio = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Inserire porte:");
                            int inPorte = Convert.ToInt32(Console.ReadLine());

                            Automobile auto = new Automobile()
                            {
                                Targa = inTarga,
                                Telaio = inTelaio,
                                NumPorte = inPorte
                            };

                            Console.WriteLine(auto);
                        }
                        catch (Exception ex){
                            Console.WriteLine($"Errore: {ex.Message}");
                        }

                        break;
                    case "2":
                        break;
                    case "Q":
                        insAbi = !insAbi;
                        break;
                    default:
                        Console.WriteLine("Errore, comando non riconosciuto");
                        break;
                }
            }
        }
    }
}