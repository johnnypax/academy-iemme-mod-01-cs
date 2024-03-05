namespace Lez02_05_ControlliComplessi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Input utente inserisci i dati della tua provincia per conoscere a cosa corrisponde la sigla
            //string provincia = "BO";

            //if (provincia.Equals("AQ"))
            //{
            //    Console.WriteLine("L'Aquila");
            //} else
            //{
            //    if (provincia.Equals("PE"))
            //    {
            //        Console.WriteLine("Pescara");
            //    }
            //    else
            //    {
            //        if (provincia.Equals("BO"))
            //        {
            //            Console.WriteLine("Bologna");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Non trovato");
            //        }
            //    }
            //}

            //---------------------------------------------------------------

            //string provincia = "BO";

            //if (provincia.Equals("AQ"))
            //    Console.WriteLine("L'Aquila");
            //else if (provincia.Equals("PE"))
            //    Console.WriteLine("Pescara");
            //else if (provincia.Equals("BO"))
            //    Console.WriteLine("Bologna");
            //else
            //    Console.WriteLine("Non trovato");

            //---------------------------------------------------------------

            string provincia = "BO";

            switch (provincia)
            {
                case "AQ":
                    Console.WriteLine("L'Aquila");
                    break;
                case "PE":
                    Console.WriteLine("Pescara");
                    break;
                case "BO":
                    Console.WriteLine("Bologna");
                    break;
                default: 
                    Console.WriteLine("Non trovato");
                    break;
            }

        }
    }
}