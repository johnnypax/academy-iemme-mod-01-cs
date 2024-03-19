using DB_lez02_paninoteca.Models;

namespace DB_lez02_paninoteca
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * Creare un piccolo sistema di gestione paninoteca.

                Ogni panino è caratterizzato da:
                - Nome
                - Descrizione
                - Prezzo
                - Vegan (SI/NO)

                Creare una classe dedicata alla sola interazione con il Database.

                Al recupero di tutto il menu:
                - Lista di tutti i panini con relativi dettagli.
                - Visualizzare tutti i panini Vegan.
                - Contare tutti gli elementi presenti in menu.
                - Calcolare il prezzo medio dei panini.

            */

            // Lista di tutti i panini con relativi dettagli.
            GestorePanino ges = new GestorePanino();
            List<Panino> menu = ges.findAll();

            //foreach (Panino p in menu)
            //{
            //    Console.WriteLine(p);
            //}

            // Visualizzare tutti i panini Vegan.
            //var paniniVegani = from panino in menu
            //                   where panino.IsVegan == true
            //                   select panino;

            //var paniniVegani = menu.Where(p => p.IsVegan == true);

            //foreach (Panino p in paniniVegani)
            //{
            //    Console.WriteLine(p);
            //}

            // Contare tutti gli elementi presenti in menu.
            Console.WriteLine(menu.Count);

            // Calcolare il prezzo medio dei panini
            Console.WriteLine(menu.Average(p => p.Prezzo));


            //bool risultato = ges.insert(new Panino()
            //{
            //    Nome = "ER BONACCIONE",
            //    Descrizione = "Bono fracico",
            //    Prezzo = 15.4f,
            //    IsVegan = false
            //});

            //if (risultato)
            //    Console.WriteLine("Tutto ok");
            //else 
            //    Console.WriteLine("Errore");

        }
    }
}
