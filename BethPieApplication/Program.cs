using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethPieApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // llama al m�todo CreateHostBuilder
            CreateHostBuilder(args).Build().Run();
        }

        // este m�todo crear� un host que ejecutara la aplicaci�n
        // primero llama Host.CreateDefaultBuilder
        // configura un generador de host con muchos valores predeterminados
        // (ver el contenido de cada linea del m�todo(-- I primera linea y remarks)
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
