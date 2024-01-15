using Browse_API.Data;
using Browse_API.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IProductsService _productsService;


    public ProductsController(ILogger<ProductsController> logger,
                                 IProductsService productsService)
    {
        _logger = logger;
        _productsService = productsService;
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
