namespace Browse_API.Services.Products
{
    public class ProductsServiceFake : IProductsService
    {
        private readonly ProductDTO[] _products =
        {
            new ProductDTO { Name = "Fake product A", Description = "Fake Description A", Price = 11},
            new ProductDTO { Name = "Fake product B", Description = "Fake Description B", Price = 22},
            new ProductDTO { Name = "Fake product C", Description = "Fake Description C", Price = 33},
        };

        public Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = _products.AsEnumerable();
            return Task.FromResult(products);
        }




    }
}
