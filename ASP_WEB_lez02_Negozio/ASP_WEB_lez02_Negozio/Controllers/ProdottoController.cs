using ASP_WEB_lez02_Negozio.Models;
using ASP_WEB_lez02_Negozio.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WEB_lez02_Negozio.Controllers
{
    public class ProdottoController : Controller
    {
        private readonly ProdottoService _service;

        public ProdottoController(ProdottoService service)
        {
            _service = service;
        }

        public IActionResult Lista()
        {
            List<Prodotto> elenco = _service.ElencoTuttiProdotti();

            return View(elenco);
        }

        public IActionResult Inserimento()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Salvataggio(Prodotto objProdotto)
        {
            if (_service.InserisciProdotto(objProdotto))
                return Redirect("/Prodotto/Lista");
            else
                return Redirect("/Prodotto/Errore");
        }

        public IActionResult Dettaglio(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return Redirect("/Prodotto/Errore");

            Prodotto? prodotto = _service.RicercaProdottoPerCodice(varCodice);
            if(prodotto is null)
                return Redirect("/Prodotto/Errore");

            return View(prodotto);
        }

        [HttpDelete]
        public IActionResult Elimina(string varCodice)
        {
            if (_service.EliminaProdottPerCodice(varCodice))
                return Ok();

            return BadRequest();
        }

        public IActionResult Modifica(string varCodice)
        {
            Prodotto? temp = _service.RicercaProdottoPerCodice(varCodice);
            if (temp is null)
                return Redirect("/Prodotto/Errore");

            return View(temp);
        }

        public IActionResult EffettuaModifica(Prodotto nuovo)
        {
            Prodotto? vecchio = _service.RicercaProdottoPerCodice(nuovo.Codice);
            if (vecchio is null)
                return Redirect("/Prodotto/Errore");

            if(!_service.ModificaProdotto(vecchio, nuovo))
                return Redirect("/Prodotto/Errore");

            return Redirect("/Prodotto/Lista");
        }
    }
}
