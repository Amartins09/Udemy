using Entity.Domain;
using Microsoft.EntityFrameworkCore;

namespace Entity.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){

        }

        public DbSet<Product> products {get;set;}
        public DbSet<Category> Categories {get;set;}
        
    }
}