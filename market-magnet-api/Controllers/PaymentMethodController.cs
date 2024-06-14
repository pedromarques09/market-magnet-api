using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace market_magnet_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        // GET: api/PaymentMethod
        [HttpGet]
        public ActionResult<IEnumerable<PaymentMethod>> GetAll()
        {
            var paymentMethods = _paymentMethodService.GetAll();
            return Ok(paymentMethods);
        }

        // GET: api/PaymentMethod/user/{userId}
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<PaymentMethod>> GetByUserId(string userId)
        {
            var paymentMethods = _paymentMethodService.GetByUserId(userId);
            return Ok(paymentMethods);
        }

        // GET: api/PaymentMethod/{id}
        [HttpGet("{id}")]
        public ActionResult<PaymentMethod> GetById(string id)
        {
            var paymentMethod = _paymentMethodService.GetById(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return Ok(paymentMethod);
        }

        // POST: api/PaymentMethod
        [HttpPost]
        public ActionResult<PaymentMethod> Create([FromBody] PaymentMethod newPaymentMethod)
        {
            _paymentMethodService.Create(newPaymentMethod);
            return CreatedAtAction(
                nameof(GetById),
                new { id = newPaymentMethod._id },
                newPaymentMethod
            );
        }

        // PUT: api/PaymentMethod/{id}
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] PaymentMethod updatedPaymentMethod)
        {
            var existingPaymentMethod = _paymentMethodService.GetById(id);
            if (existingPaymentMethod == null)
            {
                return NotFound();
            }

            _paymentMethodService.Update(updatedPaymentMethod);
            return NoContent();
        }

        // DELETE: api/PaymentMethod/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var paymentMethod = _paymentMethodService.GetById(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            _paymentMethodService.Delete(id);
            return NoContent();
        }
    }
}
