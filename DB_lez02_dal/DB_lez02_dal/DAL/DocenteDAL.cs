using DB_lez02_dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez02_dal.DAL
{
    internal class DocenteDAL : IDal<Docente>
    {
        static DocenteDAL? instance;

        public static DocenteDAL getInstance()
        {
            if (instance == null)
                instance = new DocenteDAL();

            return instance;
        }

        private DocenteDAL()
        {
            Console.WriteLine("Sono il costruttore invocato");
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Docente> findAll()
        {
            throw new NotImplementedException();
        }

        public Docente findById(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Docente t)
        {
            return false;
        }

        public bool update(Docente t)
        {
            throw new NotImplementedException();
        }
    }
}
