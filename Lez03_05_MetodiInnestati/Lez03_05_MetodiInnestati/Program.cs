namespace Lez03_05_MetodiInnestati
{
    internal class Program
    {
        static double? EffettuaOperazione(double numeratore, double denominatore)
        {
            if (denominatore != 0)
                return divisione(numeratore, denominatore);
            
            return null;
        }

        static double divisione(double varUno, double varDue)
        {
            return varUno / varDue;
        }

        static void Main(string[] args)
        {

            double a = 5.6d;
            double b = 10d;
            double? risultato = EffettuaOperazione(a, b);

            if (risultato is null)
                Console.WriteLine("Divisione per zero non possibile!");
            else
                Console.WriteLine($"Il risultato è: {risultato}");

        }
    }
}