
namespace Browse_API.Services.ProductsRepo
{
    public class ProductsRepoFake : IProductsRepo
    {
        private readonly Product[] _products =
        {
            new Product { Name = "Fake repo product D", Description = "Fake repo description D", Price = 111 },
            new Product { Name = "Fake repo product E", Description = "Fake repo description E", Price = 222 },
            new Product { Name = "Fake repo product F", Description = "Fake repo description F", Price = 333 }
        };

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = _products.AsEnumerable();
            return Task.FromResult(products);
        }
    }
}
