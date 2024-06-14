using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace market_magnet_api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        // GET: api/sale
        [HttpGet]
        public IActionResult GetAll()
        {
            var sales = _saleService.GetSales();
            return Ok(sales);
        }

        // GET: api/sale/user/last/{userId}
        [HttpGet("user/last/{userId}")]
        public IActionResult GetLastSale(string userId)
        {
            var sale = _saleService.GetLastSale(userId);
            return Ok(sale);
        }

        // GET: api/sale/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(string userId)
        {
            var sales = _saleService.GetSalesByUserId(userId);
            return Ok(sales);
        }

        // GET: api/sale/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var sale = _saleService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        // POST: api/sale
        [HttpPost]
        public IActionResult Create([FromBody] Sale sale)
        {
            _saleService.CreateSale(sale);
            return CreatedAtAction(nameof(GetById), new { id = sale._id }, sale);
        }

        // PUT: api/sale/{id}
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Sale sale)
        {
            var existingSale = _saleService.GetSaleById(id);
            if (existingSale == null)
            {
                return NotFound();
            }

            sale._id = existingSale._id;
            _saleService.UpdateSale(sale);
            return NoContent();
        }

        // DELETE: api/sale/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _saleService.DeleteSale(id);
            return NoContent();
        }
    }
}
