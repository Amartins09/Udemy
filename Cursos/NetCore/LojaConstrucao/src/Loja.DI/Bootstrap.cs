using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Loja.Data;
using Loja.Domain;
using Loja.Domain.Products;
using Loja.Data.Contexts;
using Loja.Data.Repositores;
using Loja.Domain.Sales;
using Loja.Data.Identity;
using Loja.Domain.Account;

namespace Loja.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection){

            services.AddDbContext<ApplicationDbContext>(options =>
                                    options.UseMySql(connection));


            services.AddIdentity<ApplicationUser, IdentityRole>(config => {

                    config.Password.RequireDigit = false;
                    config.Password.RequiredLength = 3;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    //Não existe mais essa opção no Core 2.1
                    //config.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            services.AddSingleton(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));            
            services.AddSingleton(typeof(IAuthentication), typeof(Authentication));
            services.AddSingleton(typeof(IManager), typeof(Manager));
            services.AddSingleton(typeof(CategoryStore));
            services.AddSingleton(typeof(ProductStore));
            services.AddSingleton(typeof(SaleFactory));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
