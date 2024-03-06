namespace Lez03_03_TaskContenitori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Titolo - AUTORE - ISBN - Casa Editrice
            string[] libro_1 = { "Il signore degli anelli", "JRRT", "123456-1225", "Casa ed 1" };
            string[] libro_2 = { "Il ritorno del re", "JRRT", "123456-1226", "Casa ed 1" };
            string[] libro_3 = { "Il visconte dimezzato", "I.Calvino", "987456-1225", "Casone editrice" };
            string[] libro_4 = { "Storia del buongiorno", "A. Christie", "456466-1225", "Casone editrice" };
            string[] libro_5 = { "Le due torri", "JRRT", "456463-1225", "Casa ed 1" };

            string[][] store = { libro_1, libro_2, libro_3, libro_4, libro_5 };

            //Contare tutti i libri di JRRT o di un autore inserito a mano.

            //string autoreDaCercare = "JRRT";
            //int contatore = 0;

            //foreach(string[] libro in store)
            //{
            //    if (libro[1].Equals(autoreDaCercare))
            //        contatore++;
            //}

            //Console.WriteLine($"Il numero di libri è: {contatore}");

            //------------------------------------------------------------------

            Console.WriteLine("Digita l'autore");
            string? autoreDaCercare = Console.ReadLine();

            int contatore;

            foreach (string[] libro in store)
            {
                if (
                    autoreDaCercare is not null && 
                    libro[1].ToLower().Trim().Equals(autoreDaCercare.ToLower().Trim())
                    )
                    contatore++;
            }

            Console.WriteLine($"Il numero di libri è: {contatore}");
        }
    }
}