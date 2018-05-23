using Loja.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Loja.Data {
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }

        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products{get;set;}

        /* COMO ATUALIZAR O BANCO DE DADOS
        dotnet ef --startup-project ..\Loja.Web\Loja.Web.csproj --project .\Loja.Data.csproj migrations add <Nome>

        APLICAR A MMODIFICAÇÃO AO BANCO DE DADOS
        dotnet ef --startup-project ..\Loja.Web\Loja.Web.csproj --project .\Loja.Data.csproj database update        
        */
    }
}