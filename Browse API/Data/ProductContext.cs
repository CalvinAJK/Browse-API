using Microsoft.EntityFrameworkCore;

namespace Browse_API.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
        { 
        }
    }
}
