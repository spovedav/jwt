using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CAPA.SITE.MVC.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        private string GetClaims(string claimType)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                // Busca el Claim específico
                var claim = HttpContext.User.FindFirst(claimType);
                return claim?.Value; // Retorna el valor del Claim, o null si no existe
            }
            return null;
        }

        protected string GetToken() => GetClaims("Token");
        
    }
}
