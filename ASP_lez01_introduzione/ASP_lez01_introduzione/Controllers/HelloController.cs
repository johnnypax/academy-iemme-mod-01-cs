using Microsoft.AspNetCore.Mvc;

namespace ASP_lez01_introduzione.Controllers
{
    [Route("api/hello")]
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Ciao sono la pagina Index");
        }

        [HttpGet("saluta")]
        public IActionResult Saluta() {
            return Ok("Ciao Giovanni"); 
        }

        [HttpGet("saluta/{valNome}")]
        public IActionResult SalutaPersonalizzato(string valNome)
        {
            return Ok($"Ciao {valNome}");
        }

        [HttpGet("saluta/{valNome}/{valCognome}")]
        public IActionResult SalutaPersonalizzato(string valNome, string valCognome)
        {
            return Ok($"Ciao {valNome} {valCognome}");
        }

        [HttpGet("numerico/{valNumero}")]
        public IActionResult EsponiNumero(int valNumero)
        {
            return Ok($"Ciao {valNumero}");
        }
    }
}
