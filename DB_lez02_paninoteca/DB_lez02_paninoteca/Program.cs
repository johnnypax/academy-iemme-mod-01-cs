using DB_lez02_paninoteca.Models;

namespace DB_lez02_paninoteca
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GestorePanino ges = new GestorePanino();
            List<Panino> menu = ges.findAll();

            foreach (Panino p in menu)
            {
                Console.WriteLine(p);
            }






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
