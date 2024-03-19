using LINQ_lez05_Correzione.Classes;

namespace LINQ_lez05_Correzione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                Creare una lista di prodotti caratterizzati da:
                - Nome
                - Descrizione
                - Prezzo
                - Categoria
                - Quantità

                Inserire un numero n di prodotti:
                - Mandare in output tutti i prodotti di una certa categoria
                - Calcolare il prezzo medio dei prodotti
                - Riepilogare le quantità numeriche per categoria di prodotto
                - Creare un report del valore del negozio calcolato come "quantità x prezzo" di ogni prodotto   
            */

            List<Prodotto> elenco = new List<Prodotto>() {
                new Prodotto(){ Nome = "Vite Philips", Categoria = "Ferramenta", Descrizione = "Svitata", Prezzo = 0.15f, Quantita = 15},
                new Prodotto(){ Nome = "Vite Piatta", Categoria = "Ferramenta", Descrizione = "Triste", Prezzo = 0.16f, Quantita = 18},
                new Prodotto(){ Nome = "Lampadina", Categoria = "Illuminazione", Descrizione = "Radiosa", Prezzo = 5.4f, Quantita = 85}
            };

            #region Mandare in output tutti i prodotti di una certa categoria
            //SELECT * FROM Prodotto WHERE categoria = "Ferramenta"
            //var risultato = from prodotto in elenco
            //                where prodotto.Categoria == "Ferramenta"
            //                select prodotto;

            //foreach (var item in risultato)
            //{
            //    Console.WriteLine($"{item.Nome}");
            //}

            //Modalità compatta
            //var risultato = elenco.Where(p => p.Categoria == "Ferramenta");

            //foreach (var item in risultato)
            //{
            //    Console.WriteLine($"{item.Nome}");
            //}
            #endregion

            #region con variabile personalizzata
            //var risultato = from prodotto in elenco
            //                where prodotto.Categoria == "Ferramenta"
            //                select new { prodotto.Nome, prodotto.Prezzo };

            //var risultato = elenco
            //    .Where(prod => prod.Categoria == "Ferramenta")
            //    .Select(p => new { p.Nome, p.Prezzo });

            //foreach (var item in risultato)
            //{
            //    Console.WriteLine($"{item.Nome} {item.Prezzo}");
            //}
            #endregion

            #region Calcolare il prezzo medio dei prodotti

            //var risultato = elenco.Average(p => p.Prezzo);
            //Console.WriteLine(risultato);

            //var risultato = from prod in elenco
            //                select prod.Prezzo;
            //Console.WriteLine(risultato.Average());

            #endregion

            #region Riepilogare le quantità numeriche per categoria di prodotto

            var risultato = from oggetto in elenco
                            group oggetto by oggetto.Categoria into contenitoreGenere
                            select contenitoreGenere;

            foreach (var categoria in risultato)
            {
                Console.WriteLine(categoria.Key + " " + categoria.Sum(prod => prod.Quantita));
            }

            #endregion

            #region Creare un report del valore del negozio calcolato come "quantità x prezzo" di ogni prodotto  

            var ris = from prod in elenco
                        where prod.Quantita > 0
                        select new { prod.Prezzo, prod.Quantita };

            Console.WriteLine( ris.Sum(p => p.Quantita * p.Prezzo) );


            #endregion

#if RELEASE
            var a = 5;

            Console.WriteLine("Ciao sono il codice in modalità RELEASE");
#else

            var a = 5;
            Console.WriteLine("Ciao sono il codice in modalità DEBUG");
#endif

        }
    }
}
