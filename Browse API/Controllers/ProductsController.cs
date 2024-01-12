using Browse_API.Data;
using Browse_API.Services.Products;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<ProductDTO>> GetProducts()
    {
        var products = _context.Products.ToList();  
        var productDtos = products.Select(product => new ProductDTO
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        }).ToList();
        return Ok(productDtos);
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
