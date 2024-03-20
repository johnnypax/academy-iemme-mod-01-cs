using DB_lez04_scuola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez04_scuola.DAL
{
    internal class DocenteDAL : IDal<Docente>
    {
        private static DocenteDAL? istanza;

        public static DocenteDAL getIstanza()
        {
            if (istanza == null)
                istanza = new DocenteDAL();

            return istanza;
        }

        private DocenteDAL() { }


        public bool Delete(Docente t)
        {
            throw new NotImplementedException();
        }

        public List<Docente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Docente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Docente t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Docente t)
        {
            throw new NotImplementedException();
        }
    }
}
