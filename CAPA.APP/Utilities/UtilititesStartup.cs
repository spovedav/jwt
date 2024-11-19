using CAPA.DOMAIN.Static;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAPA.APP.Utilities
{
    public static class UtilititesStartup
    {
        public static string Cadena { get; set; }

        public static void CargarDatosIniciales(IConfiguration configuration)
        {
            var baseDatos = configuration.GetConnectionString("DataSource");
            var catalog = configuration.GetConnectionString("Catalog");
            var user = configuration.GetConnectionString("User");
            var pass = configuration.GetConnectionString("Pass");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = baseDatos,
                InitialCatalog = catalog,
                UserID = user,
                Password = pass
            };

            Cadena = sqlConnectionStringBuilder.ConnectionString.ToString();
        }

        public static void CargarDatosInicialesSite(IConfiguration configuration)
        {
            ParametrosConfi.UrlBaseAuth = configuration["Apis:Auth:base"];
            ParametrosConfi.UrlBaseAdmin = configuration["Apis:Admin:base"];
        }
    }
}
