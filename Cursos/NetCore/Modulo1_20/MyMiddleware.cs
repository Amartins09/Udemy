using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Modulo1_20
{
    public class MyMiddleware
    {
        private RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;            
        }

        public async Task Invoke(HttpContext context)
        {
            //Request
            var start = DateTime.Now;

            await _next(context);

            var finish = DateTime.Now;

            var diff = finish.Subtract(start);


            await context.Response.WriteAsync($"Tempo de resposta: {diff.Milliseconds}");
        }
    }
}