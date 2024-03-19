using DB_lez02_dal.DAL;
using DB_lez02_dal.Models;

namespace DB_lez02_dal
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DocenteDAL
                .getInstance()
                .insert(new Docente() { });


            DocenteDAL
                .getInstance()
                .insert(new Docente() { });


            DocenteDAL
                .getInstance()
                .insert(new Docente() { });

            DocenteDAL codg = new DocenteDAL();

        }
    }
}
