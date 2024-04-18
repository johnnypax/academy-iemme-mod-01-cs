using ASP_WEB_lez05_Preferiti.Models;
using ASP_WEB_lez05_Preferiti.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASP_WEB_lez05_Preferiti.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmService _service;

        public FilmController(FilmService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<string>? lista = new List<string>();
            string? contenutoSessione = HttpContext.Session.GetString("preferiti");
            if (contenutoSessione != null)
                lista = JsonConvert.DeserializeObject<List<string>>(contenutoSessione);

            ViewBag.ListaPreferiti = lista;
            List<Film> filmList = (List<Film>)_service.RestituisciTuttiFilm();

            return View(filmList);
        }

        public IActionResult Aggiungi(string? cod)
        {
            try
            {
                List<string>? lista = new List<string>();

                string? contenutoSessione = HttpContext.Session.GetString("preferiti");
                if (contenutoSessione != null)
                {
                    lista = JsonConvert.DeserializeObject<List<string>>(contenutoSessione);
                }

                if (lista is not null && cod is not null)
                    lista.Add(cod);

                HttpContext.Session.SetString("preferiti", JsonConvert.SerializeObject(lista));


                return Ok();
            }
            catch (Exception ex)
            {
            }

            return BadRequest();

        }
    }
}
