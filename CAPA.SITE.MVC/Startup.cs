using CAPA.APP.Utilities;
using CAPA.HTTP.Interfaces;
using CAPA.HTTP.Servicio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAPA.SITE.MVC
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
            services.AddControllersWithViews();

            services.AddAuthentication("CookieAuth")
                        .AddCookie("CookieAuth", options =>
                        {
                            options.LoginPath = "/Home/Index"; // Ruta para iniciar sesión
                            options.ExpireTimeSpan = TimeSpan.FromHours(1); // Sesión activa por 1 hora
                            options.SlidingExpiration = true; // Renovar la sesión automáticamente si está activa
                        });

            UtilititesStartup.CargarDatosInicialesSite(Configuration);

            #region SERVICOS APIS
            services.AddScoped<IPeticionesHTTP, PeticionesHTTP>();
            services.AddScoped<IApiAdmin, ApiAdmin>();
            services.AddScoped<IApiAuth, ApiAuth>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //NUEVO
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
