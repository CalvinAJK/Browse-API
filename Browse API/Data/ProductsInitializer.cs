namespace Browse_API.Data
{
    public class ProductsInitializer
    {
        public static async Task SeedTestingData(ProductContext context)
        {
            if (context.Products.Any())
            {
                //db has seeded data in it
                return;
            }

            // Seed db with testing data

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Test A", Description = "Test Desc A", Price = 1, Stock = true},
                new Product { Id = 2, Name = "Test B", Description = "Test Desc B", Price = 2, Stock = false},
                new Product { Id = 3, Name = "Test C", Description = "Test Desc C", Price = 3, Stock = false},
            };
            products.ForEach(p => context.Add(p));
            await context.SaveChangesAsync();
        }
    }
}
