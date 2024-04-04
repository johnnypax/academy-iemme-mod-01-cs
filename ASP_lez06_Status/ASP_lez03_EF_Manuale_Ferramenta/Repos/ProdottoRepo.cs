using ASP_lez03_EF_Manuale_Ferramenta.Models;

namespace ASP_lez03_EF_Manuale_Ferramenta.Repos
{
    public class ProdottoRepo : IRepo<Prodotto>
    {
        private readonly FerramentaContext _context;

        public ProdottoRepo(FerramentaContext context)
        {
            _context = context;
        }

        public bool Create(Prodotto entity)
        {
            try
            {
                _context.Prodotti.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
                return false;
            }
        }

        public bool Delete(int id)
        {

            try
            {
                Prodotto? temp = Get(id);
                if (temp != null)
                {
                    _context.Prodotti.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return false;
        }

        public Prodotto? Get(int id)
        {
            return _context.Prodotti.Find(id);
        }

        public IEnumerable<Prodotto> GetAll()
        {
            return _context.Prodotti.ToList();
        }

        public bool Update(Prodotto entity)
        {
            try
            {
                _context.Prodotti.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public Prodotto? GetByCodice(string codice)
        {
            try
            {
                return _context.Prodotti.FirstOrDefault(p => p.Codice == codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
