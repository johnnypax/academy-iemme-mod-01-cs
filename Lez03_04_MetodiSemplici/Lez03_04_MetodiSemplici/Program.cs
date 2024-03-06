namespace Lez03_04_MetodiSemplici
{
    internal class Program
    {
        static void saluta()
        {
            Console.WriteLine("CIAO");
        }
        static void salutaPersonalizzato(string nominativo)
        {
            Console.WriteLine($"{nominativo} ciao, come stai?");
        }

        static void dettaglioStudente(string nome, string cognome, string? matricola)
        {
            if (matricola is null)
                matricola = "Non definita";

            Console.WriteLine($"Nome: {nome}\nCognome: {cognome}\nMatricola: {matricola}");
        }


        static int somma(int a, int b, int c)
        {
            int risultato = a + b + c;
            return risultato;

            //int b = 5;
        }


        static void stampaArray(string[] elenco)
        {
            foreach (string str in elenco)
            {
                Console.WriteLine(str);
            }
        }

        static void Main(string[] args)
        {
            string[] parco = { "BMW", "Lamborghini", "Maserati", "FIAT" };
            stampaArray(parco);

            string[] invitati = { "Giovanni", "Valeria", "Mario" };
            stampaArray(invitati);

            //saluta();
            //saluta();
            //saluta();

            //salutaPersonalizzato("Giovanni Pace");
            //salutaPersonalizzato("Valeria Verdi");
            //salutaPersonalizzato("Mario Rossi");

            //dettaglioStudente("Giovanni", "Pace", "AB1234");
            //dettaglioStudente("Valeria", "Verdi", null);

            //int sommaDiNumeri = somma(43, 56, 12);
            //Console.WriteLine(sommaDiNumeri);

            Console.WriteLine(somma(43, 56, 12));

        }
    }
}