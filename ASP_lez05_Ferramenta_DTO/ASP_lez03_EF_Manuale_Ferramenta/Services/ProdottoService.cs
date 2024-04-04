using ASP_lez03_EF_Manuale_Ferramenta.DTO;
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

        public List<ProdottoDto> RestituisciTutti()
        {
            List<ProdottoDto> elenco = this.PrendiliTutti().Select(p => new ProdottoDto()
            {
                Nom = p.Nome,
                Cat = p.Categoria,
                Cod = p.Codice,
                Des = p.Descrizione,
                Pre = p.Prezzo,
                Qua = p.Quantita
            }).ToList();

            return elenco;
        }

        
        public List<ProdottoDto> RestituisciProdottiFiltrati()
        {
            List<ProdottoDto> elenco = this.PrendiliTutti()
                .Where(e => e.Categoria != "VM")
                .Select(p => new ProdottoDto()
                    {
                        Nom = p.Nome,
                        Cat = p.Categoria,
                        Cod = p.Codice,
                        Des = p.Descrizione,
                        Pre = p.Prezzo,
                        Qua = p.Quantita
                    })
                .ToList();

            return elenco;
        }

        public bool InserisciProdotto(ProdottoDto oPro)
        {
            Prodotto pro = new Prodotto()
            {
                Categoria = oPro.Cat,
                Codice = Guid.NewGuid().ToString().ToUpper(),
                Descrizione = oPro.Des,
                Nome = oPro.Nom,
                Quantita = oPro.Qua,
                Prezzo = oPro.Pre,
                DataCreazione = DateTime.Now
            };

            return _repository.Create(pro);
        }
    }
}
