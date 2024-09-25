using Microsoft.EntityFrameworkCore;

using ShoppingCart.Modal;

namespace ShoppingCartShared.Dbcontext
{
    public class ApDbContext : DbContext 
    {
        public ApDbContext(DbContextOptions<ApDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
