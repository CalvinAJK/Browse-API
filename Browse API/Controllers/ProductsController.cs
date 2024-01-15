using Browse_API.Data;
using Browse_API.Services.Products;
using Browse_API.Services.ProductsRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Product = Browse_API.Services.ProductsRepo.Product;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IProductsService _productsService;
    private readonly IProductsRepo _productsRepo;


    public ProductsController(ILogger<ProductsController> logger,
                                 IProductsService productsService,
                                 IProductsRepo productsRepo)
    {
        _logger = logger;
        _productsService = productsService;
        _productsRepo = productsRepo;
    }

    [HttpGet]
    /*[Authorize]*/
    public async Task<IActionResult> GetProducts()
    {
        IEnumerable<ProductDTO> products = null;
        try
        {
            products = await _productsService.GetProductsAsync();
        }
        catch
        {
            _logger.LogWarning("Exception occured using Products service");
            products = Array.Empty<ProductDTO>();
        }
        return Ok(products.ToList());
    }

    [HttpGet("Repo")]
    public async Task<IActionResult> Repo()
    {
        IEnumerable<Product> products = null;
        try
        {
            products = await _productsRepo.GetProductsAsync();
        }
        catch
        {
            _logger.LogWarning("Exception occured using Products repo");
            products = Array.Empty<Product>();
        }
        return Ok(products.ToList());
    }


/*    [HttpGet("search")]
    [Authorize]
    public ActionResult<IEnumerable<Product>> SearchProducts([FromQuery] string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return BadRequest("Search term is required.");
        }

        var matchingProducts = _context.Products
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .ToList();

        return Ok(matchingProducts);
    }*/

}
