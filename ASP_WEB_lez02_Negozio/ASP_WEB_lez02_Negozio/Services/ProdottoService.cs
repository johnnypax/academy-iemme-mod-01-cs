using ASP_WEB_lez02_Negozio.Models;
using ASP_WEB_lez02_Negozio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WEB_lez02_Negozio.Services
{
    public class ProdottoService
    {
        private readonly ProdottoRepository _repository;

        public ProdottoService(ProdottoRepository repo)
        {
            _repository = repo;
        }

        public List<Prodotto> ElencoTuttiProdotti()
        {
            return _repository.GetAll();
        }

        public bool InserisciProdotto(Prodotto pro)
        {
            return _repository.Insert(pro);
        }

        public Prodotto? RicercaProdottoPerCodice(string varCodice)
        {
            return _repository.GetByCodice(varCodice);
        }

        public bool EliminaProdottPerCodice(string varCodice)
        {
            Prodotto? temp = _repository.GetByCodice(varCodice);
            if (temp == null)
                return false;

            return _repository.Delete(temp.ProdottoId);
        }

        public bool ModificaProdotto(Prodotto vecchio, Prodotto nuovo)
        {
            vecchio.Nome = nuovo.Nome;
            vecchio.Descrizione = nuovo.Descrizione;
            //...

            return _repository.Update(vecchio);
        }


    }
}
