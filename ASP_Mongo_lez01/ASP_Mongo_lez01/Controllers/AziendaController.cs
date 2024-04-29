using ASP_Mongo_lez01.Models;
using ASP_Mongo_lez01.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Mongo_lez01.Controllers
{
    [ApiController]
    [Route("api/impiegati")]
    public class AziendaController : Controller
    {
        private readonly AziendaService _service;

        public AziendaController(AziendaService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult ListaDipendenti() {
            return Ok(_service.Restituisci());
        }

        [HttpPost]
        public IActionResult InserisciDipendente(ImpiegatoDTO objDto)
        {
            if (ModelState.IsValid)
            {
                if (_service.Inserimento(objDto))
                    return Ok(new Risposta() { Status = "SUCCESS" });
            }
            return BadRequest();
        }


    }
}
