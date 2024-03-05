namespace Lez02_03_TaskTemperatura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Creare un sistema di controllo accessi al ristorante, in input (sotto forma di variabile) ci sarà la
             * temperatura.
             * 
             * Se la temperatura è maggiore o uguale a 37.5° allora non permettere l'ingresso al ristorante.
             * 
             * ATTENZIONE: non ci vuole un medico per stabilire che al di sotto dei 35° abbiamo qualche problema o al di
             * sopra dei 42 eviterei l'ingresso al ristorante.
             */

            float temp = 36.5f;

            if (temp >= 35.0f && temp <= 42.0f)
                if (temp < 37.5f)
                    Console.WriteLine("Puoi entrare");
                else
                    Console.WriteLine("Non puoi entrare");
            else
                Console.WriteLine("Errore di validazione");
        }
    }
}