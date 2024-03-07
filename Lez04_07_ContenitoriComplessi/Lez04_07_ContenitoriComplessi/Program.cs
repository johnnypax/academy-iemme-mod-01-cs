using Lez04_07_ContenitoriComplessi.Classes;

namespace Lez04_07_ContenitoriComplessi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> elenco = new List<string>();
            //elenco.Add("Maserati");
            //elenco.Add("Lamborghini");
            //elenco.Add("BMW");
            //elenco.Add("FIAT");

            //for(int i = 0; i < elenco.Count; i++)
            //{
            //    Console.WriteLine(elenco[i]);
            //}

            //------------------------------------------------

            List<Contatto> rubrica = new List<Contatto>();
            rubrica.Add(new Contatto()
            {
                Nome = "Giovanni",
                Cognome = "Pace",
                Telefono = "1234",
                Email = "gio@pace.com"
            });
            rubrica.Add(new Contatto()
            {
                Nome = "Valeria",
                Cognome = "Verdi",
            });
            rubrica.Add(new Contatto()
            {
                Nome = "Mario",
                Cognome = "Rossi",
            });

            foreach(Contatto temp in rubrica)
            {
                Console.WriteLine(temp);
            }
        }
    }
}