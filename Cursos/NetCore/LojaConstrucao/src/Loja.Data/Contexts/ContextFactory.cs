using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Loja.Data.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(){
            return CreateDbContext(null);
        }

        public ApplicationDbContext CreateDbContext(string[] args){
            var builderConfiguration = new  ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json");
            var configuration = builderConfiguration.Build();
            var conn = configuration.GetConnectionString("Default");

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseMySql(conn);

            return new ApplicationDbContext(builder.Options);
        }
    }
}