namespace Lez01_02_ControlliSemplici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variabili

            //int eta = 15;
            //int eta;
            //eta = 15;

            //eta = 4;
            //Console.WriteLine(eta);


            //string nome;
            //nome = "Giovanni";

            //String? cognome;         //Nullable

            //cognome = "Pace";
            //Console.WriteLine(cognome);

            //cognome = null;
            //Console.WriteLine(cognome);

            //COPARAZIONI

            /*
             * >
             * <
             * >=
             * <=
             * ==
             * !=
             */

            //Console.WriteLine(6 == 5);

            /*
             * if(condizione){
             *      //Codice in caso positivo
             * } else {
             *      //Codice in caso negativo
             * }
             */

            //if (false)
            //{
            //    Console.WriteLine("Sono il ramo TRUE");
            //}
            //else
            //{
            //    Console.WriteLine("Sono il ramo FALSE");
            //}

            //---------------------------------------------

            //int eta = 15;

            //if (eta >= 18)
            //{
            //    Console.WriteLine("Sei maggiorenne");
            //}
            //else
            //{
            //    Console.WriteLine("Sei minorenne");
            //}

            //--------------------------------------------- ESPANSIONE ORIZZONTALE (no buono)

            //int eta = 8500;

            //if(eta <= 0)
            //{
            //    Console.WriteLine("Non penso tu sia un embrione in stadio prorotipale...");
            //}
            //else
            //{
            //    if(eta >= 130)
            //    {
            //        Console.WriteLine("Te li porti veramente bene...");
            //    }
            //    else
            //    {
            //        if (eta >= 18)
            //        {
            //            Console.WriteLine("Sei maggiorenne");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Sei minorenne");
            //        }
            //    }                
            //}

            //-----------------------------------------------------------------------

            //int eta = -3000;
            //      TRUE   ||   FALSE           = TRUE
            //         1    +       0           = 1

            //int eta = 40000;
            //        FALSE ||  TRUE            = TRUE
            //            0  +     1            = 1

            //int eta = 16;
            ////      FALSE   ||  FALSE           = FALSE
            ////          0   +   0               = 0
            //if ((eta <= 0) || (eta >= 130))
            //{
            //    Console.WriteLine("Errore di validazione");
            //}
            //else
            //{
            //    Console.WriteLine("Procedi con la tua operazione");
            //}

            //----------------------------------------------------------------


            //int eta = -3000;
            //  FALSE  &&   TRUE        = FALSE
            //      0   *       1       = 0

            //int eta = 40000;
            //  TRUE    &&  FALSE       = FALSE
            //      1    *      0       = 0

            //int eta = 15;
            ////  TRUE    &&  TRUE        = TRUE
            ////      1   *      1        = 1
            //if (eta > 0 && eta < 120)
            //{
            //    Console.WriteLine("Procedi con la tua operazione");
            //}
            //else
            //{
            //    Console.WriteLine("Errore di validazione");
            //}

            //--------------------------------------------------------------

            bool esito = false;

            Console.WriteLine( !esito );

            Console.WriteLine( esito );



        }
    }
}