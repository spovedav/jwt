using CAPA.APP.Interfaces.Servicios;
using CAPA.DOMAIN.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CAPA.API.ADMIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices usuarioService;

        public UsuarioController(IUsuarioServices usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("Get-All")]
        [Authorize]
        public ActionResult<ResponseDto<List<UsuarioDto>>> GetAll()
        {
            var resulta = usuarioService.GetAll();
            return Ok(resulta);
        }
    }
}
