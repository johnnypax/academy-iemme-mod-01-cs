using API_lez07_JWT.Filters;
using API_lez07_JWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_lez07_JWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpPost("login")]
        public IActionResult Loggati(UserLogin objLogin)
        {
            //TODO: Verifica accesso, emissione JWT
            string tipoUtente = "";
            if (objLogin.Username == "giovanni" && objLogin.Password == "1234")
            {
                tipoUtente = "ADMIN";
            }
            if (objLogin.Username == "mario" && objLogin.Password == "1234")
            {
                tipoUtente = "USER";
            }

            if (tipoUtente != "" && objLogin.Username is not null) {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, objLogin.Username),
                    new Claim("UserType", tipoUtente),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),      //Evito che due dispositivi abbiano lo stesso JWT TOken (rubato)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Archety.dev",
                    audience: "Popolo",
                    claims: claims,          //Body o Payload del JWT
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized();
        }

        [HttpGet("utenteprofilo")]
        [AutorizzaUtentePerTipo("USER")]
        public IActionResult DammiInformazioniUtente()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = "Dati sensibili USER"
            });
        }

        [HttpGet("adminprofilo")]
        [AutorizzaUtentePerTipo("ADMIN")]
        public IActionResult DammiInformazioniAmministratore()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = "Dati sensibili ADMIN"
            });
        }
    }
}
