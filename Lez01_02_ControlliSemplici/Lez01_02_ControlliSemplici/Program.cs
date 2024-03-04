namespace Lez01_02_ControlliSemplici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * if(condizione){
             *      //Codice in caso positivo
             * } else {
             *      //Codice in caso negativo
             * }
             */

            int eta = 15;

            if(eta >= 18)
            {
                Console.WriteLine("Sei maggiorenne");
            } else
            {
                Console.WriteLine("Sei minorenne");
            }
        }
    }
}