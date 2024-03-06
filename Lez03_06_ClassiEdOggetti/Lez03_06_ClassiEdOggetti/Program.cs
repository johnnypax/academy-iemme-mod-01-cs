namespace Lez03_06_ClassiEdOggetti
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Bottiglia coca = new Bottiglia();
            coca.materiale = "PET";
            coca.colore = "Trasparente";
            coca.diametro = 12.5f;
            coca.altezza = 25.0f;
            coca.contenuto = "Cola";

            //Console.WriteLine(coca.materiale);
            Console.WriteLine(coca.calcolaVolume());
            coca.stampaDettagli();

            Bottiglia acqua = new Bottiglia()
            {
                contenuto = "Acqua",
                altezza = 12.4f,
                diametro = 16.5f,
                colore = "Blu"
            };

            acqua.stampaDettagli();
        }

    }
}