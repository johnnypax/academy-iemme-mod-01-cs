using EF_CF_lez01_Migrations_Intro.Models;
using EF_CF_lez01_Migrations_Intro.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_CF_lez01_Migrations_Intro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContattoController : Controller
    {
        private readonly ContattoService _service;

        public ContattoController(ContattoService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public ActionResult<List<Contatto>> ElencoContatti()
        {
            return Ok(_service.RestituisciTuttiContatti());
        }


    }
}
