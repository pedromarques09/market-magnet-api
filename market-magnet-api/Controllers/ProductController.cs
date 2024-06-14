using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace market_magnet_api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        // GET: api/product/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(string userId)
        {
            var products = _productService.GetProductsByUserId(userId);
            return Ok(products);
        }

        // GET: api/product/{id}
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

        // GET: api/product/user/last/{userId}
        [HttpGet("user/last/{userId}")]
        public IActionResult GetLatestProduct(string userId)
        {
            var product = _productService.GetLatestProduct(userId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product._id }, product);
        }

        // PUT: api/product/{id}
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

        // PUT: api/product/quantity
        [HttpPut("quantity")]
        public IActionResult UpdateStock([FromBody] Payload payload)
        {
            var updatedProducts = _productService.UpdateStock(payload);
            return Ok(updatedProducts);
        }

        // DELETE: api/product/{id}
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
}