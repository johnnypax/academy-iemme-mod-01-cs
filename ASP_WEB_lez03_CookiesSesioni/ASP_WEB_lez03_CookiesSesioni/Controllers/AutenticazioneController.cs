using ASP_WEB_lez03_CookiesSesioni.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WEB_lez03_CookiesSesioni.Controllers
{
    public class AutenticazioneController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult VerificaCredenziali(Utente objUtente)
        {
           if (objUtente.Username is null || objUtente.Password is null)
                return Redirect("/Autenticazione/Login");

            if (objUtente.Username == "giovanni" && objUtente.Password == "pace")
            {
                HttpContext.Response.Cookies.Append("userLogged", "ADMIN");
                return Redirect("/Autenticazione/Profiloamministratore");
            }

            if (objUtente.Username == "valeria" && objUtente.Password == "verdi")
            {
                HttpContext.Response.Cookies.Append("userLogged", "USER");
                return Redirect("/Autenticazione/Profiloutente");
            }

            return Redirect("/Autenticazione/Login");
        }

        public IActionResult Profiloamministratore()
        {
            string? valoreCookie = HttpContext.Request.Cookies["userLogged"];

            if (valoreCookie is not null && valoreCookie.Equals("ADMIN"))
                return View();

            return Redirect("/Autenticazione/Login");
        }

        public IActionResult Profiloutente()
        {
            string? valoreCookie = HttpContext.Request.Cookies["userLogged"];

            if (valoreCookie is not null && valoreCookie.Equals("USER"))
                return View();

            return Redirect("/Autenticazione/Login");
        }
    }
}
