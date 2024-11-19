using CAPA.DOMAIN.DTOs;
using CAPA.DOMAIN.Static;
using CAPA.HTTP.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAPA.HTTP.Servicio
{
    public class ApiAdmin : IApiAdmin
    {
        private readonly IPeticionesHTTP _http;
        public ApiAdmin(IPeticionesHTTP _http) {
            this._http = _http;
            this._http.SetUrlBase(ParametrosConfi.UrlBaseAdmin);
        }

        public async Task<ResponseDto<List<UsuarioDto>>> GetAll(string metodo, string Token, object queryParameto = null)
        {
            var resultado = new ResponseDto<List<UsuarioDto>>();
            try
            {
                resultado = await _http.GetAsync<ResponseDto<List<UsuarioDto>>>(metodo, Token, queryParameto);

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.TieneError = true;
                resultado.CodigoError = "EX";
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
