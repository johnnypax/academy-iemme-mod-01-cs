using Lez05_02_StaticiEreditari.Classes;

namespace Lez05_02_StaticiEreditari
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Giocattolo ectoUno = new Automobile();
            Giocattolo autoDue = new Automobile();
            Giocattolo tren = new Trenino();

            List<Giocattolo> elenco = new List<Giocattolo>();
            elenco.Add(ectoUno);
            elenco.Add(autoDue);
            elenco.Add(tren);

            foreach(Giocattolo gio in elenco)
            {
                if(gio.GetType() == typeof(Trenino))
                {
                    Trenino temp = (Trenino)gio;
                    temp.rumoreTrenino();
                }
                
            }


        }
    }
}