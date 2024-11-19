using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA.DOMAIN.DTOs.Auth
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Username { get; set; }
        public string Correo { get; set; }
    }
}
