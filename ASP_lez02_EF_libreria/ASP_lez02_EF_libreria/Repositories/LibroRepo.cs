using ASP_lez02_EF_libreria.Models;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ASP_lez02_EF_libreria.Repositories
{
    public class LibroRepo : IRepo<Libro>
    {
        private static LibroRepo? _instance;

        public static LibroRepo getInstance()
        {
            if (_instance == null)
                _instance = new LibroRepo();
            return _instance;
        }

        private LibroRepo() { }

        public bool delete(int id)
        {
            bool risultato = false;
            using (AccLez29LibreriaContext ctx = new AccLez29LibreriaContext())
            {
                try
                {
                    Libro lib = ctx.Libros.Single(c => c.LibroId == id);
                    ctx.Libros.Remove(lib);
                    ctx.SaveChanges();

                    risultato = true;

                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;

        }

        public List<Libro> GetAll()
        {
            List<Libro> elenco = new List<Libro>();

            using (AccLez29LibreriaContext ctx = new AccLez29LibreriaContext())
            {
                elenco = ctx.Libros.ToList();
            }

            return elenco;
        }

        public Libro? GetById(int id)
        {
            Libro? lib = null;

            using (AccLez29LibreriaContext ctx = new AccLez29LibreriaContext())
                lib = ctx.Libros.FirstOrDefault(l => l.LibroId == id);

            return lib;
        }

        public bool insert(Libro t)
        {
            bool risultato = false;
            using (AccLez29LibreriaContext ctx = new AccLez29LibreriaContext())
            {
                try
                {
                    ctx.Libros.Add(t);
                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return risultato;
        }

        public bool update(Libro t)
        {
            bool risultato = false;

            using (AccLez29LibreriaContext ctx = new AccLez29LibreriaContext())
            {
                try
                {
                    Libro temp = ctx.Libros.Single(l => l.Codice == t.Codice);

                    t.LibroId =     temp.LibroId;
                    t.Titolo =      t.Titolo is not null        ? t.Titolo          : temp.Titolo;
                    t.Autore =      t.Autore is not null        ? t.Autore          : temp.Autore;
                    t.Descrizione = t.Descrizione is not null   ? t.Descrizione     : temp.Descrizione;
                    t.Prezzo =      t.Prezzo == 0               ? temp.Prezzo          : t.Prezzo;
                    t.Quantita =    t.Quantita is null          ? temp.Quantita        : t.Quantita;

                    ctx.Entry(temp).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }

        public Libro? GetByCodice(string codice)
        {
            Libro? lib = null;

            using (AccLez29LibreriaContext ctx = new AccLez29LibreriaContext())
                lib = ctx.Libros.FirstOrDefault(l => l.Codice == codice);

            return lib;
        }
    }
}
