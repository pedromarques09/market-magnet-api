using market_magnet_api.Models;
using market_magnet_api.Services;
using market_magnet_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace market_magnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Customer>> GetByUserId(string userId)
        {
            var customers = _customerService.GetCustomersByUserId(userId);
            return Ok(customers);
        }

        // GET: api/Customer/{id}
        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> Create([FromBody] Customer newCustomer)
        {
            _customerService.CreateCustomer(newCustomer);
            return CreatedAtAction(nameof(GetById), new { id = newCustomer._id }, newCustomer);
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Customer updatedCustomer)
        {
            var existingCustomer = _customerService.GetCustomerById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            updatedCustomer._id = id;
            _customerService.UpdateCustomer(updatedCustomer);
            return NoContent();
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
