namespace Lez03_02_ContenitoriComplessi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string[] stuUno = { "Giovanni Pace", "12345", "PCAGNN" };
            //string[] stuDue = { "Valeria Verdi", "12346", "VLRVRD" };
            //string[] stuTre = { "Mario Rossi", "12347", "MRRRSS" };

            //string[][] elenco = { stuUno, stuDue, stuTre };

            //for(int i=0; i<elenco.Length; i++)
            //{
            //    string[] temp = elenco[i];

            //    for(int k=0; k<temp.Length; k++)
            //    {
            //        Console.WriteLine(temp[k]);
            //    }
            //}

            //for (int i = 0; i < elenco.Length; i++)
            //{
            //    for (int k = 0; k < elenco[i].Length; k++)
            //    {
            //        Console.WriteLine(elenco[i][k]);
            //    }
            //}

            // -------------------------------------------

            string[] stuUno = { "Giovanni Pace", "12345", "PCAGNN" };
            string[] stuDue = { "Valeria Verdi", "12346", "VLRVRD" };
            string[] stuTre = { "Mario Rossi", "12347", "MRRRSS" };
            string[][] elenco = { stuUno, stuDue, stuTre };

            Console.WriteLine("Inserisci il codice fiscale:");
            string? inputUtente = Console.ReadLine();   

            for(int i=0; i<elenco.Length; i++)
            {
                if (
                    inputUtente is not null && 
                    elenco[i][2].ToUpper().Equals(inputUtente.ToUpper().Trim())
                    )
                {
                    Console.WriteLine($"Nome: {elenco[i][0]}\nMatricola: {elenco[i][1]}");
                }
            }
        }
    }
}