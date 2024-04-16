using ASP_WEB_lez01_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WEB_lez01_test.Controllers
{
    public class HelloController : Controller
    {
        public String salutaGenerico()
        {
            return "Ciao Enrico";
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Titolo = "Ciao, titolo della pagina";
            ViewBag.Sottotitolo = "Sono il sottotitolo";
            ViewBag.Numero = 5;
            ViewBag.SalutaEnrico = salutaGenerico();

            Persona per = new Persona() { 
                Nominativo = "Giovanni Pace",
                CodFis = "PCAGNN"
            };

            return View(per);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona() { Nominativo = "Giovanni Pace", CodFis = "PCAGNN" });
            personas.Add(new Persona() { Nominativo = "Valeria Verdi", CodFis = "VLRVRD" });
            personas.Add(new Persona() { Nominativo = "Marika Mariko", CodFis = "MRKMRK" });

            return View(personas);
        }
    }
}
