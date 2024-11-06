using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlowingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _service.GetEmployeesAsync();

            return Ok(employees);
        }

        [HttpGet("{id:guid}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid employee id");

            var employee = await _service.GetEmployeeByIdAsync(id);

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForCreateDto employeeForCreateDto)
        {
            //ActionFilter
            var createdEmployeeGuid = await _service.CreateEmployeeAsync(employeeForCreateDto);

            return CreatedAtRoute("EmployeeById", new { id = createdEmployeeGuid });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            //ActionFilter
            await _service.UpdateEmployeeAsync(id, employeeForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _service.DeleteEmployeeAsync(id);

            return NoContent();
        }
    }
}