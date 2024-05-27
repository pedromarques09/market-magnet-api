using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }

       [HttpGet("user/{userId}")]
    public IActionResult GetByUserId(string userId)
    {
        var products = _productService.GetProductsByUserId(userId);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        _productService.CreateProduct(product);
        return CreatedAtAction(nameof(GetById), new { id = product._id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] Product product)
    {
        var existingProduct = _productService.GetProductById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        product._id = existingProduct._id;
        _productService.UpdateProduct(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var existingProduct = _productService.GetProductById(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        _productService.DeleteProduct(id);
        return NoContent();
    }
}
