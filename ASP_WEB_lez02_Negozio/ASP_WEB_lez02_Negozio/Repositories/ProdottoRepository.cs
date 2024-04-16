using ASP_WEB_lez02_Negozio.Models;

namespace ASP_WEB_lez02_Negozio.Repositories
{
    public class ProdottoRepository : IRepository<Prodotto>
    {
        private readonly AccLez06NegozioContext _context;

        public ProdottoRepository(AccLez06NegozioContext ctx)
        {
            _context = ctx;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Prodotto> GetAll()
        {
            return _context.Prodottos.ToList(); 
        }

        public Prodotto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Prodotto? GetByCodice(string varCodice)
        {
            Prodotto? tmp = null;
            try
            {
                tmp = _context.Prodottos.FirstOrDefault(p => p.Codice == varCodice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tmp;
        }

        public bool Insert(Prodotto t)
        {
            try
            {
                _context.Prodottos.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool Update(Prodotto t)
        {
            throw new NotImplementedException();
        }
    }
}
