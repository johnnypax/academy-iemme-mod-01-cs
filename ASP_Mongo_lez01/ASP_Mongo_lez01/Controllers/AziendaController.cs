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


        [HttpGet("{varMatricola}")]
        public IActionResult RestituisciDipendente(String varMatricola)
        {
            ImpiegatoDTO? temp = _service.RestituisciImpiegato(new ImpiegatoDTO() { Mat = varMatricola});
            
            if(temp != null)
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = temp
                });

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = "Impiegato non trovato"
            });
        }


        [HttpDelete("{varMatricola}")]
        public IActionResult EliminaDipendente(String varMatricola)
        {
            if (_service.EliminaImpiegato(new ImpiegatoDTO() { Mat = varMatricola }))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                });

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = "Impiegato non trovato"
            });
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

        [HttpPut]
        public IActionResult ModificaDipendente(ImpiegatoDTO objDto)
        {
            if (ModelState.IsValid)
            {
                if(_service.ModificaImpiegato(objDto))
                    return Ok(new Risposta()
                    {
                        Status = "SUCCESS",
                    });

                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = "Impiegato non modificato"
                });
            }

            return BadRequest();
        }
    }
}
