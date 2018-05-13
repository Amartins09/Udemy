using Entity.Domain;
using Microsoft.EntityFrameworkCore;

namespace Entity.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){

        }

        public DbSet<Product> Products {get;set;}
        public DbSet<Category> Categories {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(50);
        }    
    }
}