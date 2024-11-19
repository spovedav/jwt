using CAPA.HTTP.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CAPA.SITE.MVC.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IApiAdmin _apiAdmin;
        private readonly IConfiguration configuration;

        public UsuarioController(IApiAdmin _apiAdmin, IConfiguration configuration)
        {
            this._apiAdmin = _apiAdmin;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                string metodo = configuration["Apis:Admin:get-all"];

                var resultado = await _apiAdmin.GetAll(metodo, GetToken());

                return View(resultado.Data ?? new System.Collections.Generic.List<DOMAIN.DTOs.UsuarioDto>());
            }
            catch (System.Exception ex)
            {
                ViewBag.error = "Error";
                return View();
            }
        }
    }
}
