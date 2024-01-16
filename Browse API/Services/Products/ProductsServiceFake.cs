namespace Browse_API.Services.Products
{
    public class ProductsServiceFake : IProductsService
    {
        private readonly ProductDTO[] _products =
        {
            new ProductDTO { Name = "Fake product A", Description = "Fake Description A", Price = 11, InStock = true},
            new ProductDTO { Name = "Fake product B", Description = "Fake Description B", Price = 22, InStock = true},
            new ProductDTO { Name = "Fake product C", Description = "Fake Description C", Price = 33, InStock = false},
        };

        public Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = _products.AsEnumerable();
            return Task.FromResult(products);
        }

        public Task<IEnumerable<ProductDTO>> GetProductsByNameAsync(string searchTerm)
        {
            var filteredProducts = _products
                .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .AsEnumerable();

            return Task.FromResult(filteredProducts);
        }
    }
}
