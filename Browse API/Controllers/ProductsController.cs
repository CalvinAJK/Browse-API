using Browse_API.Data;
using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductContext _context;

    public ProductsController(ProductContext context)
    {
        _context = context;
    }

    // ... Existing code ...

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        var products = _context.Products.ToList();
        return Ok(products);
    }


    [HttpGet("search")]
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
    }

}
