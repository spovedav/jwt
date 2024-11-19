using CAPA.DOMAIN.DTOs.Auth;
using CAPA.DOMAIN.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA.APP.Interfaces.Servicios
{
    public interface IJwtServices
    {
        AuthResponse GenerateToken(TableUsuario usuario);
    }
}
