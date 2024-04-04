using ASP_lez03_EF_Manuale_Ferramenta.DTO;
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
        public ActionResult<List<ProdottoDto>> ElencoProdottiFiltrati()
        {
            return _service.RestituisciProdottiFiltrati();
        }

        [HttpGet("nonfiltrati")]
        public ActionResult<List<ProdottoDto>> ElencoProdottiNonFiltrati()
        {
            return _service.RestituisciTutti();
        }

        [HttpPost("inserisci")]
        public IActionResult InserisciProdotto(ProdottoDto objProd)
        {
            if (objProd.Nom is not null && objProd.Nom.Trim().Equals(""))
                return BadRequest();
            if (objProd.Cat is not null && objProd.Cat.Trim().Equals(""))
                return BadRequest();
            if (objProd.Pre < 0)
                return BadRequest();

            if (_service.InserisciProdotto(objProd))
            {
                return Ok();
            }      
            
            return BadRequest();
        }
    }
}
