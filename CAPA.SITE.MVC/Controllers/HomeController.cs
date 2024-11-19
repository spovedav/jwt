using CAPA.HTTP.Interfaces;
using CAPA.SITE.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CAPA.SITE.MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiAuth _apiAuth;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger,
                              IConfiguration configuration,
                              IApiAuth _apiAuth)
        {
            _logger = logger;
            this.configuration = configuration;
            this._apiAuth = _apiAuth;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Index(string usuario, string contraseña)
        {
            string metodo = configuration.GetValue<string>("Apis:Auth:auth");

            var resultado = await _apiAuth.AutenticateGetToken(metodo, usuario, contraseña, null);

            if (!string.IsNullOrEmpty(resultado.Token))
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario),
                        new Claim("Correo", resultado.Correo), // Ejemplo de claim personalizado
                        new Claim("Token", resultado.Token)
                    };

                var identidad = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identidad);

                await HttpContext.SignInAsync("CookieAuth", principal);

                return RedirectToAction("Index", "Usuario");
            }

            ViewBag.Error = "Usuario o contraseña inválidos.";
            return View();
        }

        // Acción para cerrar sesión
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index");
        }
    }
}
