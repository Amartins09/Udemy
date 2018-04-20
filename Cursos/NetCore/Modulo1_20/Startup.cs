using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Modulo1_20
{
    public class Startup
    {
        private IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env){
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json");
            
            builder.AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MyMiddleware>();
            app.UseStaticFiles();

            var applicationName = _configuration.GetValue<string>("AplicationName");

            app.Run(context => context.Response.WriteAsync($"Ola Mundo 2 ! {applicationName} ! "));
        }
    }
}