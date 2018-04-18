using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Modulo1_20
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .Configure(
                    app => {
                        app.Run(context => context.Response.WriteAsync("Ola Mundo2"));
                    }
                )
                .Build();

            host.Run();
        }
    }
}
