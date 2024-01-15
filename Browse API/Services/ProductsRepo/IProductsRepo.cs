namespace Browse_API.Services.ProductsRepo
{
    public interface IProductsRepo
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
