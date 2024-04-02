using ASP_lez01_introduzione.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_lez01_introduzione.Controllers
{
    [ApiController]
    [Route("api/studente")]
    public class StudenteController : Controller
    {
        [HttpGet("test")]               // GET - api/studente/test
        public IActionResult TestGet()
        {
            return Ok("Test di GET");
        }

        [HttpPost("test")]              // POST - api/studente/test
        public IActionResult TestPost()
        {
            return Ok("Test di POST");
        }

        [HttpGet("dettaglio")]
        public ActionResult<Studente?> RecuperaStudente()
        {
            Studente stu = new Studente()
            {
                Id = 1,
                Nome = "Giovanni",
                Cognome = "Pace",
                Matricola = "AB1234"
            };

            return Ok(stu);
        }

        [HttpGet("elenco")]
        public ActionResult<List<Studente>> ElencoStudenti()
        {
            List<Studente> lista = new List<Studente>
            {
                new Studente() {Id = 1,Nome = "Giovanni",Cognome = "Pace",Matricola = "AB1234"},
                new Studente() {Id = 2,Nome = "Valeria",Cognome = "Verdi",Matricola = "AB1235"}
            };

            return Ok(lista);
        }

        [HttpPost("inserisci")]
        public ActionResult Inserisci(Studente objStu)
        {
            return Ok(objStu);
        }
    }
}
