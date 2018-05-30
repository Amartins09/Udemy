using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Loja.Data;
using Loja.Domain;
using Loja.Domain.Products;

namespace Loja.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection){
            services.AddDbContext<ApplicationDbContext>(options =>
                                    options.UseMySql(connection));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>)));
            services.AddSingleton(typeof(CategoryStore));
        }
    }
}
