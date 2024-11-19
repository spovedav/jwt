using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA.DOMAIN.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }

        public bool IsValid(ref string mensajeError)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(UserName))
                sb.Append("El Usuario esta vacío");

            if (string.IsNullOrEmpty(UserName))
                sb.Append("El Usuario esta vacío");

            mensajeError = sb.ToString();

            return !(sb.Length > 0);
        }
    }
}
