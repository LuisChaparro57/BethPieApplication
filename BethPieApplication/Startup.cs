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
    //aqui estan los metodos ConfgureServices y Configure. Son llamados autom�ticamente por ASP.NET Core
    //Esos m�todos tienen argumentos (no son nulos). Son elpunyo de entrada para agragar elementos de la colecci�n de servicioos
    //As� que el contenedor de inyecci�n de dependencia
    //Alli debemos agregar todos los servicios (integrados o propios) que usaremos dentro de la aplicai�n 

    public class Startup
    {
        // Este metodo es llamdo en timepo de ejecuci�n. Se usa para adicionar servicios al contenedor.
        // Para mayor informaci�n sobre como configurar suaplicaci+on, visite https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPieRepository, MockPieRepository>();
            //Adicionamos soporte para MVC para que podamos tabajarla
            services.AddControllersWithViews();
         }

        // Metodo llamado en timepo de ejecuci�n. Se usa para canlizar las peticiones HTTP.
        // En el cuerpo ya tiene algunos valores prederminados
        // Al usar la inyecci�n de dependencia, el m�todo recibir� una instancia de WebHostEnvironment 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // En el cuerpo ya tiene algunos valores prederminados
            // As� comprobaremos si estamos en desarrollo (la aplicaci�n estar� configurada de forma predeterminada para desarrollo)
            // Lo que realmante va a hacer: -ir a propiedades del proyecto - (click de / llave)
            // Al seleccionar Debug la variable ASPNETCORE_ENVIRONMENT est� con valor Dvelopment
            // Esr valor se pude reemplazar por: producci�n o puesta en escena.
            // As� el m�todo Configure permitehacer cosas en funcion delentorno de ejecui�n de la aplicaci�n
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Adicionamos dos componentes de middleware (2 primmeros). Y, al conectar el middleware correpondiente, se mostraran las
            // excepciones en la p�gina deldesarrollador (si las hay)
            app.UseHttpsRedirection(); //redirige las soluciones en la canalizaci�n
            app.UseStaticFiles(); //permite asegurar que deforma predeterminada la aplicai�n servir� para archivos est�ticos
                                  //(im�gnes, archivos javascript, arvivos CSS). Busca archivos est�ticos el directorio wwwroot
            //El c�digo a continuaci�n, estaba alli de forma predeterminada. Y es responsable del mensaje "Hola Mundo"

            //Los middleware UseRouting y UseEndPoins permite que MVC responda a las solicitudes entrantes
            //El necesita mapear una solicitud entrante con el c�digo correcto que se ejecutar�
            app.UseRouting();


            //Como no queremos responder a todas las solicitudes con "Hola MUndo", reemplazamos el siguiente c�digo

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
