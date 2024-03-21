using System.Collections;

namespace Lez06_01_HashTable_Disctionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();

            ht.Add("AB1234", "Giovanni Pace");
            ht.Add("AB1235", "Valeria Verdi");
            ht.Add("AB1236", "Mario Rossi");
            ht.Add(1, "Mario Rossi");
            ht.Add(12.0f, 78.8d);
            ht.Add(98.0d, "Mario Rossi");

            ////Console.WriteLine( ht["AB1235"] );

            ////if (ht.ContainsKey("AB1235"))
            ////    ht.Remove("AB1235");

            ////Console.WriteLine(ht.ContainsKey("AB1235") ? "Trovato":"Non trovato");

            //foreach (DictionaryEntry item in ht)
            //{
            //    Console.WriteLine($"Chiave: {item.Key} valore: {item.Value}");
            //}

            // ----------------------------------------------------------------

            //Dictionary<String, String> dictionary = new Dictionary<String, String>();

            //dictionary.Add("AB1234", "Giovanni Pace");
            //dictionary.Add("AB1235", "Valeria Verdi");
            //dictionary.Add("AB1236", "Mario Rossi");

            //foreach (KeyValuePair<String, String> item in dictionary)
            //{
            //    Console.WriteLine($"Chiave: {item.Key} valore: {item.Value}");
            //}

            // ----------------------------------------------------------------



            Hashtable config = new Hashtable();
            config.Add("username", "Ab1234");
            config.Add("password", "blablabla");
            config.Add("host", "http://....");
            config.Add("port", 3306);
            config.Add("ht", ht);

            foreach (DictionaryEntry item in config)
            {
                Console.WriteLine($"Chiave: {item.Key} valore: {item.Value}");
                if (item.Value is not null && item.Value.GetType() == typeof(Hashtable))
                {
                    foreach (DictionaryEntry it in (Hashtable)item.Value)
                        Console.WriteLine($"Chiave: {it.Key} valore: {it.Value}");
                }
            }
        }
    }
}
