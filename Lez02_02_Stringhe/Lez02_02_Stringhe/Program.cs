namespace Lez02_02_Stringhe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string? nominativo = null;
            //Console.WriteLine(nominativo);

            //Console.WriteLine( "Giovanni " + "Pace" );

            //int a = 2;
            //int b = 5;

            //Console.WriteLine("La somma dei numeri è: " + a + b);       //... è 25
            //Console.WriteLine("La somma dei numeri è: " + (a + b));       //... è 7
            //Console.WriteLine(a + b + " la somma dei numeri è");

            //Operazioni semplici tra stringhe:
            /*
             * Scrivere un programma che mandi on output le seguenti due stringhe:
             * 
             * Giovanni Pace è 37 anni vecchio ed ha una temperatura corporea di 36.5°C.
             * Mario Rossi è 23 anni vecchio ed ha una temperatura corporea di 38.5°C.
             */

            //string nominativo = "Giovanni Pace";
            //int eta = 37;
            //float temp = 36.5f;

            //Console.WriteLine( $"{nominativo} è {eta} anni vecchio ed ha una temperatura di {temp}°C" );

            //nominativo = "Mario Rossi";
            //eta = 23;
            //temp = 38.5f;

            //Console.WriteLine( $"{nominativo} è {eta} anni vecchio ed ha una temperatura di {temp}°C" );

            //--------------------------------------------------------------

            //Console.WriteLine( $"Il risultato è: {5 + 6}" );

            //string nominativo = "Giovanni Pace";
            //Console.WriteLine($"Il nome {nominativo} ha una lunghezza di {nominativo.Length}");

            //int lunghezza = nominativo.Length;
            //Console.WriteLine($"Il nome {nominativo} ha una lunghezza di {lunghezza}");

            //----------------------------------------------------

            //string? frase = "Mi piace tanto \"programmare\"";
            //Console.WriteLine(frase);

            //----------------------------------------------------

            String frase = "Sono Giovanni Pace e mi piace programmare";
            //Console.WriteLine( frase.IndexOf("Pappagallo") );

            if (frase.IndexOf("Pappagallo") != -1)
                Console.WriteLine("Trovato");
            else
                Console.WriteLine("Non trovato");

        }
    }
}