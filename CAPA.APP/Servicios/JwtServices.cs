using CAPA.APP.Interfaces.Servicios;
using CAPA.DOMAIN.DTOs.Auth;
using CAPA.DOMAIN.Entity;
using CAPA.DOMAIN.Static;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CAPA.APP.Servicios
{
    public class JwtServices : IJwtServices
    {
        private string KEY;

        public JwtServices()
        {
            KEY = ParametrosApiConfi.KEY;
        }

        public AuthResponse GenerateToken(TableUsuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
            var credenciales = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            DateTime fechaExpiracion = DateTime.Now.AddDays(1);

            var cliams = new[]
            {
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Expired, fechaExpiracion.ToShortDateString())
            };

            var congiToken = new JwtSecurityToken(
            issuer: "mi-dominio",
            audience: "mi-dominio",
            claims: cliams,
            signingCredentials: credenciales
            );

            var token = new JwtSecurityTokenHandler().WriteToken(congiToken);

            return new AuthResponse() {
                Token = token,
                Correo = usuario.Email,
                FechaExpiracion = fechaExpiracion,
                Username = usuario.UserName,
            };
        }
    }
}
