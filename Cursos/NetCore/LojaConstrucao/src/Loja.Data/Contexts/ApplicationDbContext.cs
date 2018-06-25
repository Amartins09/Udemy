using Loja.Domain.Products;
using Loja.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Loja.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Loja.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }

        /* COMO ATUALIZAR O BANCO DE DADOS
        dotnet ef --startup-project ..\Loja.Web\Loja.Web.csproj --project .\Loja.Data.csproj migrations add <Nome>

        APLICAR A MMODIFICAÇÃO AO BANCO DE DADOS
        dotnet ef --startup-project ..\Loja.Web\Loja.Web.csproj --project .\Loja.Data.csproj database update        
        */
}