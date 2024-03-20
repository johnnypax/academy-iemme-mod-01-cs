using DB_lez04_scuola.DAL;
using DB_lez04_scuola.Models;
using DB_lez04_scuola.Utilities;

namespace DB_lez04_scuola
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Studente stu = new Studente()
            {
                Nominativo = "CIccio Pastrocchio",
                Matricola = "AB4446"
            };

            Console.WriteLine(StudenteDAL.getIstanza().Insert(stu) ? "Stappo!" : "Errore");

        }
    }
}
