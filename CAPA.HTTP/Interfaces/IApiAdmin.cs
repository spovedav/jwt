using CAPA.DOMAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAPA.HTTP.Interfaces
{
    public interface IApiAdmin
    {
        Task<ResponseDto<List<UsuarioDto>>> GetAll(string metodo, string Token, object queryParameto = null);
    }
}
