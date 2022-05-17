using BethPieApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BethPieApplication
{
    //Esta es la clase de inicio
    //aqui estan los metodos ConfgureServices y Configure. Son llamados automáticamente por ASP.NET Core
    //Esos métodos tienen argumentos (no son nulos). Son elpunyo de entrada para agragar elementos de la colección de servicioos
    //Así que el contenedor de inyección de dependencia
    //Alli debemos agregar todos los servicios (integrados o propios) que usaremos dentro de la aplicaión 

    public class Startup
    {
        // Este metodo es llamdo en timepo de ejecución. Se usa para adicionar servicios al contenedor.
        // Para mayor información sobre como configurar suaplicaci+on, visite https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPieRepository, MockPieRepository>();
            //Adicionamos soporte para MVC para que podamos tabajarla
            services.AddControllersWithViews();
         }

        // Metodo llamado en timepo de ejecución. Se usa para canlizar las peticiones HTTP.
        // En el cuerpo ya tiene algunos valores prederminados
        // Al usar la inyección de dependencia, el método recibirá una instancia de WebHostEnvironment 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // En el cuerpo ya tiene algunos valores prederminados
            // Así comprobaremos si estamos en desarrollo (la aplicación estará configurada de forma predeterminada para desarrollo)
            // Lo que realmante va a hacer: -ir a propiedades del proyecto - (click de / llave)
            // Al seleccionar Debug la variable ASPNETCORE_ENVIRONMENT está con valor Dvelopment
            // Esr valor se pude reemplazar por: producción o puesta en escena.
            // Así el método Configure permitehacer cosas en funcion delentorno de ejecuión de la aplicación
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Adicionamos dos componentes de middleware (2 primmeros). Y, al conectar el middleware correpondiente, se mostraran las
            // excepciones en la página deldesarrollador (si las hay)
            app.UseHttpsRedirection(); //redirige las soluciones en la canalización
            app.UseStaticFiles(); //permite asegurar que deforma predeterminada la aplicaión servirá para archivos estáticos
                                  //(imágnes, archivos javascript, arvivos CSS). Busca archivos estáticos el directorio wwwroot
            //El código a continuación, estaba alli de forma predeterminada. Y es responsable del mensaje "Hola Mundo"

            //Los middleware UseRouting y UseEndPoins permite que MVC responda a las solicitudes entrantes
            //El necesita mapear una solicitud entrante con el código correcto que se ejecutará
            app.UseRouting();


            //Como no queremos responder a todas las solicitudes con "Hola MUndo", reemplazamos el siguiente código

            // endpoints.MapGet("/", async context =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            // con
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern:"{controller=Home}/{action=Index}/{id?}");
               
            });
        }
    }
}
