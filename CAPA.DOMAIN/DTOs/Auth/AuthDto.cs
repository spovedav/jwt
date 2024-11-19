using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA.DOMAIN.DTOs.Auth
{
    public class AuthDto
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public bool IsValid(ref string mensajeError)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(UserName))
                sb.Append("El Usuario no puede estar vacío");

            if (string.IsNullOrEmpty(PassWord))
                sb.Append("El PassWord no puede estar vacío");

            mensajeError = sb.ToString();

            return (sb.Length > 0);
        }
    }
}
