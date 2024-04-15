using ASP_lez03_EF_Manuale_Ferramenta.DTO;
using ASP_lez03_EF_Manuale_Ferramenta.Models;
using ASP_lez03_EF_Manuale_Ferramenta.Repos;

namespace ASP_lez03_EF_Manuale_Ferramenta.Services
{
    public class ProdottoService : IService<Prodotto>
    {
        private readonly ProdottoRepo _repository;

        public ProdottoService(ProdottoRepo repository)
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

        public bool EliminaProdotto(ProdottoDto oPro)
        {
            if(oPro.Cod is not null)
            {
                Prodotto? temp = _repository.GetByCodice(oPro.Cod);

                if(temp is not null)
                    return _repository.Delete(temp.ProdottoId);
            }
            return false;
        }

        /// <summary>
        /// Funzione di incremento o decremento sul contesto
        /// </summary>
        /// <param name="varMod"></param>
        /// <returns></returns>
        private bool IncrDecr(ProdottoDto oPro, bool varMod)
        {
            if(oPro.Cod is not null)
            {
                Prodotto? temp = _repository.GetByCodice(oPro.Cod);
                if (temp is not null)
                {
                    temp.Quantita = varMod ? temp.Quantita + 1 : temp.Quantita - 1;

                    if (temp.Quantita < 0)
                        return false;

                    return _repository.Update(temp);
                }
            }

            return false;
        }

        public bool Incrementa(ProdottoDto oPro)
        {
            return this.IncrDecr(oPro, true);
        }
        public bool Decrementa(ProdottoDto oPro)
        {
            return this.IncrDecr(oPro, false);
        }

        public List<ProdottoDto> Ricerca(QueryDto oQue)
        {
            List<ProdottoDto> elenco = _repository.GetByAllFields(oQue.Contenuto)
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

        public ProdottoDto? RicercaPerCodice(ProdottoDto objProd)
        {
            if (objProd.Cod != null)
            {
                Prodotto? pro = _repository.GetByCodice(objProd.Cod);

                if (pro != null)
                    return new ProdottoDto()
                    {
                        Cod = pro.Codice,
                        Cat = pro.Categoria,
                        Des = pro.Descrizione,
                        Pre = pro.Prezzo,
                        Qua = pro.Quantita,
                        Nom = pro.Nome
                    };
            }

            return null;
            
        }
    }
}
