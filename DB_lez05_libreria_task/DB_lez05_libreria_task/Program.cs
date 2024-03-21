using DB_lez05_libreria_task.DAL;
using DB_lez05_libreria_task.Models;
using DB_lez05_libreria_task.Utils;

namespace DB_lez05_libreria_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Utente? ute = UtenteDAL.getInstance().GetById(2);

            //Prestito? pre = PrestitoDAL.getInstance().GetById(3);



            Utente? ute = UtenteDAL.getInstance().GetById(1);
            if (ute is not null)
            {
                if(UtenteDAL.getInstance().Delete(ute))
                    Console.WriteLine("Stappo!");
                else
                    Console.WriteLine("Errore di esecuzione della query");
            }
            else
                Console.WriteLine("Utente non trovato");

        }
    }
}
