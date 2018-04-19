using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Modulo1_20
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<MyMiddleware>();

            app.Run(context => context.Response.WriteAsync("Ola Mundo 2 ! "));
        }
    }
}