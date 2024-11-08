using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlowingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _service.GetCustomersAsync();

            return Ok(customers);
        }

        [HttpGet("{id:guid}", Name = "CustomerById")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid customer id");
            var customer = await _service.GetCustomerByIdAsync(id);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreateDto customerForCreateDto)
        {
            var createdCustomerGuid = await _service.CreateCustomerAsync(customerForCreateDto);

            return CreatedAtRoute("CustomerById", new { id = createdCustomerGuid }, createdCustomerGuid);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] CustomerForUpdateDto customerForUpdateDto)
        {
            await _service.UpdateCustomerAsync(id, customerForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletCustomer(Guid id)
        {
            await _service.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}
