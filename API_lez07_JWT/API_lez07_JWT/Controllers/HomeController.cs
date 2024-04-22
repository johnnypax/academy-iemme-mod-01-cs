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
            if(objLogin.Username == "giovanni" && objLogin.Password == "1234")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, objLogin.Username),
                    new Claim("UserType", "USER"),
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
    }
}
