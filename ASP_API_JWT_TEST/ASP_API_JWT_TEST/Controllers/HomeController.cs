using ASP_API_JWT_TEST.Auth;
using ASP_API_JWT_TEST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP_API_JWT_TEST.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HomeController : Controller
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel model)
        {
            // Qui dovresti avere una logica per validare l'utente con il database
            if (model.Username == "exampleUser" && model.Password == "examplePassword")
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserType", "USER")  // Aggiungi il tipo di utente come claim
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "YourIssuer",
                    audience: "YourAudience",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized();
        }

        [HttpGet("owner-data")]
        [AuthorizeUserType("OWNR")]
        public IActionResult GetOwnerData()
        {
            // Solo gli utenti con tipo "OWNR" possono accedere a questo metodo
            return Ok("Dati sensibili per il proprietario");
        }

        [HttpGet("user-data")]
        [AuthorizeUserType("USER")]
        public IActionResult GetUserData()
        {
            // Solo gli utenti con tipo "OWNR" possono accedere a questo metodo
            return Ok(new Risposta(){
                Status = "SUCCESS",
                Data = "Dati sensibili per l'utente" 
            });
        }
    }
}
