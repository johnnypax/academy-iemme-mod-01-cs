using ASP_lez03_EF_Manuale_Ferramenta.Models;
using ASP_lez03_EF_Manuale_Ferramenta.Repos;
using ASP_lez03_EF_Manuale_Ferramenta.Services;
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
        public ActionResult<List<Prodotto>> ElencoProdottiFiltrati()
        {
            return _service.RestituisciProdottiFiltrati();
        }

        [HttpGet("nonfiltrati")]
        public ActionResult<List<Prodotto>> ElencoProdottiNonFiltrati()
        {
            return _service.RestituisciTutti();
        }
    }
}
