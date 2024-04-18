using ASP_WEB_lez03_CookiesSesioni.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WEB_lez03_CookiesSesioni.Controllers
{
    public class AuthsessController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult VerificaCredenziali(Utente objUtente)
        {
            if (objUtente.Username is null || objUtente.Password is null)
                return Redirect("/Authsess/Login");

            if (objUtente.Username == "giovanni" && objUtente.Password == "pace")
            {
                HttpContext.Session.SetString("userLogged", "ADMIN");
                return Redirect("/Authsess/Profiloamministratore");
            }

            if (objUtente.Username == "valeria" && objUtente.Password == "verdi")
            {
                HttpContext.Session.SetString("userLogged", "USER");
                return Redirect("/Authsess/Profiloutente");
            }

            return Redirect("/Authsess/Login");
        }

        public IActionResult Profiloamministratore()
        {
            string? utenteLoggato = HttpContext.Session.GetString("userLogged");
            if(utenteLoggato != null && utenteLoggato.Equals("ADMIN")) 
                return View();

            return Redirect("/Authsess/Login");
        }

        public IActionResult Profiloutente()
        {
            string? utenteLoggato = HttpContext.Session.GetString("userLogged");
            if (utenteLoggato != null && utenteLoggato.Equals("USER"))
                return View();

            return Redirect("/Authsess/Login");
        }
    }
}
