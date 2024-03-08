namespace Lez05_03_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SCRITTURA
            //string path = "C:\\Users\\ACADEMY\\Desktop\\test.txt";
            string? path = Path.GetDirectoryName(typeof(Program).Assembly.Location);

            string contenuto = "Ciao Mario Rossi";

            try
            {
                if (path is not null)
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(contenuto);

                        sw.WriteLine("CIao");
                        sw.WriteLine("CIccio");
                    }

                Console.WriteLine("Tutto ok!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //LETTURA
            //string path = "C:\\Users\\ACADEMY\\Desktop\\test.txt";

            //try
            //{
            //    using(StreamReader sr = new StreamReader(path))
            //    {
            //        string? line;

            //        while((line = sr.ReadLine()) != null)
            //        {
            //            Console.WriteLine(line);
            //        }

            //    }
            //} catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            Console.ReadLine();

        }
    }
}