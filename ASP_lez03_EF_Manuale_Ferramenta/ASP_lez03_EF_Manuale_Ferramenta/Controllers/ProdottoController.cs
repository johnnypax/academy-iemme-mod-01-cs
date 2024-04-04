using ASP_lez03_EF_Manuale_Ferramenta.Models;
using ASP_lez03_EF_Manuale_Ferramenta.Repos;
using Microsoft.AspNetCore.Mvc;

namespace ASP_lez03_EF_Manuale_Ferramenta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdottoController : Controller
    {
        private readonly IRepo<Prodotto> _repository;

        public ProdottoController(IRepo<Prodotto> repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Prodotto>> RestituisciTuttiProdotto()
        {
            return Ok(_repository.GetAll());
        }
    }
}
