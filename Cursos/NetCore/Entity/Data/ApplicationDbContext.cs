using Entity.Domain;
using Microsoft.EntityFrameworkCore;

namespace Entity.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){

        }

        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
        }    
    }
}