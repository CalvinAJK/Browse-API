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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(p =>
            {
                p.Property(c => c.Name).IsRequired();
                p.Property(d => d.Description).IsRequired();
                p.Property(e => e.Price).IsRequired();
            });
        }
    }
}
