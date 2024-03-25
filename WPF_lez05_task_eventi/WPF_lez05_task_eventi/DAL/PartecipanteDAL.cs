using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_lez05_task_eventi.Models;

namespace WPF_lez05_task_eventi.DAL
{
    internal class PartecipanteDAL : IDal<Partecipante>
    {
        private static PartecipanteDAL? istanza;

        public static PartecipanteDAL getIstanza()
        {
            if(istanza == null)
                istanza = new PartecipanteDAL();

            return istanza;
        }

        private PartecipanteDAL() { }

        public List<Partecipante> GetAll()
        {
            List<Partecipante> risultato = new List<Partecipante>();

            using (AccLez28TaskEventiContext ctx = new AccLez28TaskEventiContext())
            {
                try
                {
                    risultato = ctx.Partecipantes.ToList();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }

        public bool Insert(Partecipante t)
        {
            bool risultato = false;

            using (AccLez28TaskEventiContext ctx = new AccLez28TaskEventiContext())
            {
                try
                {
                    ctx.Partecipantes.Add(t);
                    ctx.SaveChanges();
                    risultato = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return risultato;
        }
    }
}
