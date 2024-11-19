using CAPA.DOMAIN.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAPA.HTTP.Interfaces
{
    public interface IApiAuth
    {
        Task<AuthResponse> AutenticateGetToken(string metodo, string UserName, string Password, string Token);
    }
}
