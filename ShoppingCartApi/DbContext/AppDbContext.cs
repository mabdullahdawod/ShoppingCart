using Microsoft.EntityFrameworkCore

using ShoppingCart.Modal;

namespace ShoppingCartApi.DbContext
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) {
        
        
        }

         public DbSet<Product> Products { get; set; }
    }
}
