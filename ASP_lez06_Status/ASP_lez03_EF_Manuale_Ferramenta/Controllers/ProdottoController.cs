using ASP_lez03_EF_Manuale_Ferramenta.DTO;
using ASP_lez03_EF_Manuale_Ferramenta.Repos;
using ASP_lez03_EF_Manuale_Ferramenta.Services;
using ASP_lez03_EF_Manuale_Ferramenta.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ASP_lez03_EF_Manuale_Ferramenta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdottoController : Controller
    {
        private readonly ProdottoService _service;

        public ProdottoController(ProdottoService service)
        {
            _service = service;
        }

        [HttpGet("filtrati")]
        public ActionResult<Risposta> ElencoProdottiFiltrati()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciProdottiFiltrati()
            });
        }

        [HttpGet("nonfiltrati")]
        public ActionResult<Risposta> ElencoProdottiNonFiltrati()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }

        [HttpPost("inserisci")]
        public ActionResult<Risposta> InserisciProdotto(ProdottoDto objProd)
        {
            List<string> listaErrori = new List<string>();  

            if (objProd.Nom is null || objProd.Nom.Trim().Equals(""))
                listaErrori.Add("Nome vuoto");

            if (objProd.Cat is null || objProd.Cat.Trim().Equals(""))
                listaErrori.Add("Categoria vuota");

            if (objProd.Pre < 0)
                listaErrori.Add("Prezzo errato");

            if (_service.InserisciProdotto(objProd))
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
                });
            }
            else
            {
                listaErrori.Add("Inserimento fallito");
            }

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = listaErrori
            });
        }

        [HttpDelete("elimina/{varCod}")]
        public ActionResult Delete(string varCod)
        {
            if (_service.EliminaProdotto(new ProdottoDto() { Cod = varCod }))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
                });

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = "Eliminazione non effettuata"
            });

        }
    }
}
