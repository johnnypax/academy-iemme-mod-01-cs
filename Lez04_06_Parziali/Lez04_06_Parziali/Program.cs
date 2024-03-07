using Lez04_06_Parziali.Classes;

namespace Lez04_06_Parziali
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona per = new Persona()
            {
                CodiceFiscale = "",
                Cognome = "",
                Nome = "",
                Sesso = "",
                DataNascita = new DateTime(2022)
            };
        }
    }
}