using CAPA.DOMAIN.DTOs;
using CAPA.DOMAIN.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA.APP.Interfaces.Servicios
{
    public interface IUsuarioServices
    {
        ResponseDto<List<UsuarioDto>> GetAll();

        AuthResponse AutenticarLoguin(AuthDto request, ref string mensajeError);
    }
}
