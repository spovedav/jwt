using CAPA.APP.Interfaces.Respositorio;
using CAPA.APP.Interfaces.Servicios;
using CAPA.APP.Servicios;
using CAPA.APP.Utilities;
using CAPA.INFRE.Respositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CAPA.API.AUTH
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            UtilititesStartup.CargarDatosIniciales(Configuration);


            services.AddScoped<IDbConnection>(_ => new SqlConnection(UtilititesStartup.Cadena));

            /*
            string cadena2 = UtilititesStartup.Cadena;

            services.AddScoped<IDbConnection>(opciones =>
            {
                var factory = SqlClientFactory.Instance;
                var conn = factory.CreateConnection();
                conn.ConnectionString = cadena2;
                conn.Open();
                return conn;
            });
            */

            #region SERVICOS
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<IJwtServices, JwtServices>();
            #endregion

            #region REPOSITORIOS
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(optios =>
                {
                    optios.SwaggerEndpoint("/swagger/v1/swagger.json", "CAPA V1");
                    optios.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
