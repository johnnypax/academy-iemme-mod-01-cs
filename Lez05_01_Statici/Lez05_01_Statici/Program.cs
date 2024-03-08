using Lez05_01_Statici.Classes;

namespace Lez05_01_Statici
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Automobile.stampaContatore();

            //Console.WriteLine(Automobile.Contatore);

            Automobile autoUno = new Automobile("Blu");
            Automobile autoDue = new Automobile("Gialla");

            Automobile.stampaContatore();

            //Console.WriteLine(Automobile.Contatore);

            //Automobile.Contatore = -23;           //Non permesso


        }
    }
}