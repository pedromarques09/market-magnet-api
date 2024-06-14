using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace market_magnet_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentConditionController : ControllerBase
    {
        private readonly IPaymentConditionService _paymentConditionService;

        public PaymentConditionController(IPaymentConditionService paymentConditionService)
        {
            _paymentConditionService = paymentConditionService;
        }

        // GET: api/paymentcondition
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_paymentConditionService.GetAllPaymentConditions());
        }

        // GET: api/paymentcondition/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_paymentConditionService.GetPaymentConditionById(id));
        }

        // GET: api/paymentcondition/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(string userId)
        {
            return Ok(_paymentConditionService.GetPaymentConditionsByUserId(userId));
        }

        // POST: api/paymentcondition
        [HttpPost]
        public IActionResult Post([FromBody] PaymentCondition paymentCondition)
        {
            _paymentConditionService.CreatePaymentCondition(paymentCondition);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/paymentcondition/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PaymentCondition paymentCondition)
        {
            paymentCondition._id = id;
            _paymentConditionService.UpdatePaymentCondition(paymentCondition);
            return Ok();
        }

        // DELETE: api/paymentcondition/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _paymentConditionService.DeletePaymentCondition(id);
            return Ok();
        }
    }
}
