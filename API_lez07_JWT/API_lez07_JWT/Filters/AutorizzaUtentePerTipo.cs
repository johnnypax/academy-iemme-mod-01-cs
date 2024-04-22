using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API_lez07_JWT.Filters
{
    public class AutorizzaUtentePerTipo : Attribute, IAuthorizationFilter
    {
        private readonly string _tipologiaUtenteRichiesta;

        public AutorizzaUtentePerTipo(string tipoUtente)
        {
            _tipologiaUtenteRichiesta = tipoUtente;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claims = context.HttpContext.User.Claims;
            var userType = claims.FirstOrDefault(c => c.Type == "UserType")?.Value;     //O USER o ADMIN

            if (userType == null || userType != _tipologiaUtenteRichiesta)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }
        }
    }
}
