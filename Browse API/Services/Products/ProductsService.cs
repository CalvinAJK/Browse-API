namespace Browse_API.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _client;

        public ProductsService(HttpClient client, IConfiguration configuration)
        {
            var baseUrl = configuration["WebServices:UnderCutters:BaseURL"] ?? "";

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new InvalidOperationException("BaseURL is missing or empty in configuration.");
            }

            client.BaseAddress = new Uri(baseUrl);
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var uri = "api/product";
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadAsAsync<IEnumerable<ProductDTO>>();
            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByNameAsync(string searchTerm)
        {
            var uri = "api/product";
            var response = await _client.GetAsync(uri);

            // Handle non-success status codes if needed
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<ProductDTO>();
            }

            var allProducts = await response.Content.ReadAsAsync<IEnumerable<ProductDTO>>();

            // Filter products locally based on the name or description
            var filteredProducts = allProducts
                .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return filteredProducts;
        }

    }
}
