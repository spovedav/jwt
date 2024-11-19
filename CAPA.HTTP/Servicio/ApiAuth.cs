using CAPA.DOMAIN.DTOs.Auth;
using CAPA.DOMAIN.Static;
using CAPA.HTTP.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAPA.HTTP.Servicio
{
    public class ApiAuth : IApiAuth
    {
        private readonly IPeticionesHTTP _http;
        public ApiAuth(IPeticionesHTTP _http)
        {
            this._http = _http;
            this._http.SetUrlBase(ParametrosConfi.UrlBaseAuth);
        }

        public async Task<AuthResponse> AutenticateGetToken(string metodo, string UserName, string Password, string Token)
        {
            try
            {
                metodo = $"{metodo}?UserName={UserName}&Pass={Password}";
                var result = await _http.GetAsync<AuthResponse>(metodo, Token);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
