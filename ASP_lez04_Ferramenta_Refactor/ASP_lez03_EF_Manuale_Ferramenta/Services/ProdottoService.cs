using ASP_lez03_EF_Manuale_Ferramenta.Models;
using ASP_lez03_EF_Manuale_Ferramenta.Repos;

namespace ASP_lez03_EF_Manuale_Ferramenta.Services
{
    public class ProdottoService : IService<Prodotto>
    {
        private readonly IRepo<Prodotto> _repository;

        public ProdottoService(IRepo<Prodotto> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Prodotto> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<Prodotto> RestituisciTutti()
        {
            return this.PrendiliTutti().ToList()
        }

        
        public List<Prodotto> RestituisciProdottiFiltrati()
        {
            IEnumerable<Prodotto> elenco = _repository.GetAll();
            return elenco.Where(e => e.Categoria != "VM").ToList();
        }
    }
}
