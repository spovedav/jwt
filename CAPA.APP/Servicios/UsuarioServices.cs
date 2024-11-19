using CAPA.APP.Interfaces.Respositorio;
using CAPA.APP.Interfaces.Servicios;
using CAPA.DOMAIN.DTOs;
using CAPA.DOMAIN.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA.APP.Servicios
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IJwtServices _jwtServices;
        public UsuarioServices(IJwtServices _jwtServices, IUsuarioRepositorio _usuarioRepositorio)
        {
            this._jwtServices = _jwtServices;
            this._usuarioRepositorio = _usuarioRepositorio;
        }

        public ResponseDto<List<UsuarioDto>> GetAll()
        {
            var respose = new ResponseDto<List<UsuarioDto>>();

            respose.Data = _usuarioRepositorio.GetAll().Select(x => new UsuarioDto()
            {
                Email = x.Email,
                Id = x.Id,
                Password = x.Password,
                UserName = x.UserName,
            }).ToList();

            return respose;
        }

        public AuthResponse AutenticarLoguin(AuthDto request, ref string mensajeError)
        {
            if(request is null)
                throw new ArgumentNullException(nameof(request));

            if (request.IsValid(ref mensajeError))
                return null;

            var usuarioData = _usuarioRepositorio.GetUsuario(request.UserName, request.PassWord);

            if (usuarioData == null)
            {
                mensajeError = $"El Usuario {request.UserName}, no pudo ser encontrado";
                return null;
            }

            return _jwtServices.GenerateToken(usuarioData);
        }
    }
}
