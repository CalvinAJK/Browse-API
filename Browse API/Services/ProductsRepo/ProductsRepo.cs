using Browse_API.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Browse_API.Services.ProductsRepo
{
    public class ProductsRepo : IProductsRepo
    {
        private readonly ProductContext _productsContext;

        public ProductsRepo(ProductContext productsContext)
        {
            _productsContext = productsContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _productsContext.Products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock
            }).ToListAsync();
            return products;
        }
    }
}


