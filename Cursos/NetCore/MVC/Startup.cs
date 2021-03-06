﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC.Repository;

namespace MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            /* Inicializar o repositorio atraves da Dependency Injection  */
            services.AddTransient<IPeopleRepository>(repository => new PeopleRepository("http://SqlServer:8081"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}")
                    .MapRoute(
                        name: "about-rout",
                        template: "About",
                        defaults: new {controller="Home", action="About"}
                    )
                    .MapRoute(
                        name: "contact-rout",
                        template: "Contact",
                        defaults: new {controller="Home", action="Contact"}
                    )
                    .MapRoute(
                        name: "apiProduct",
                        template: "api/product/{action=Get}/{id?}",
                        defaults: new {Controller="Product"} 
                    );
            });
        }
    }
}
