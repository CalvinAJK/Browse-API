using Browse_API.Data;

namespace Browse_API.Services.Products
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();

        /*Task<IEnumerable<Product>> SearchProducts(string searchTerm);*/

    }
}
