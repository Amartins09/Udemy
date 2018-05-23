using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Loja.Data;

namespace Loja.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection){
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connection));
        }
    }
}
