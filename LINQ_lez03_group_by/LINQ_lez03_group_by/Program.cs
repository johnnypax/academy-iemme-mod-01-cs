using LINQ_lez03_group_by.Classes;

namespace LINQ_lez03_group_by
{
    internal class Program
    {
        #region Main
        static void Main(string[] args)
        {
            #region Gestione new {}
            //var stud = new { Nome = "Giovanni", Cognome = "Pace", Eta = 37 };

            //Console.WriteLine($"Nome: {stud.Nome} Cognome: {stud.Cognome}");
            //Console.WriteLine(stud);
            //Console.WriteLine(typeof(stud));              //Non posso chiedere il suo tipo... non esiste!
            #endregion

            List<Libro> elenco = new List<Libro>() {
                new Libro("Libro A", "Autore 1", "Fantasy"),
                new Libro("Libro B", "Autore 2", "Sci-Fi"),
                new Libro("Libro C", "Autore 1", "Horror"),
                new Libro("Libro D", "Autore 3", "Fantasy"),
                new Libro("Libro E", "Autore 2", "Horror")
            };

            // var ris = condizione ? esito positivo : esito negativo

            //Esulta se è fantasy, altrimenti rimani deluso...
            var risultato = from libro in elenco
                            select libro.Genere.Equals("Fantasy") ? "Yuhuuuuu è fantasy " + libro.Titolo : "Non è fantasy " + libro.Titolo;

            foreach (var libro in risultato)
            {
                Console.WriteLine(libro);
            }

            #region selezione parziale
            //var risultato = from libro in elenco
            //                where libro.Autore.Equals("Autore 1")
            //                select new { Titolo = libro.Titolo, Genere = libro.Genere };

            //foreach(var item in risultato)
            //{
            //    Console.WriteLine($"{item.Titolo} {item.Genere}");
            //}
            #endregion

            #region GROUP BY, raggruppamento
            //var risultato = from libro in elenco
            //                //where libro.Genere.Equals("Fantasy")
            //                group libro by libro.Genere into contenitoreGeneri
            //                select contenitoreGeneri;

            //foreach(var genere in risultato)
            //{
            //    Console.WriteLine(genere.Key);

            //    foreach(Libro lib in genere)
            //    {
            //        Console.WriteLine(lib.stampaLibro());
            //    }
            //}
            #endregion
        }
        #endregion
    }
}
