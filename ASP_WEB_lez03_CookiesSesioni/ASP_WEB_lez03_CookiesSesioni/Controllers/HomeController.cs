using ASP_WEB_lez03_CookiesSesioni.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ASP_WEB_lez03_CookiesSesioni.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Append("linguaggio", "ITA");
            HttpContext.Response.Cookies.Append("dimensioneFont", "22");

            Persona per = new Persona()
            {
                Nome = "Giovanni",
                Cognome = "Pace"
            };
            HttpContext.Response.Cookies.Append("utente", JsonConvert.SerializeObject(per));


            return View();
        }

        public IActionResult Verifica()
        {
            ViewBag.lingua = HttpContext.Request.Cookies["linguaggio"];
            ViewBag.font = HttpContext.Request.Cookies["dimensioneFont"];

            string? persona = HttpContext.Request.Cookies["utente"];
            if (persona != null)
                ViewBag.utente = JsonConvert.DeserializeObject<Persona>(persona);

            return View();
        }
    }
}
