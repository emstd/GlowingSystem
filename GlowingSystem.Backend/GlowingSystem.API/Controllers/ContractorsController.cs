using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlowingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorService _service;

        public ContractorsController(IContractorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetContractors()
        {
            var contractors = await _service.GetContractorsAsync();

            return Ok(contractors);
        }

        [HttpGet("{id:guid}", Name = "ContractorById")]
        public async Task<IActionResult> GetContractorById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid contractor id");
            var contractor = await _service.GetContractorByIdAsync(id);

            return Ok(contractor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContractor([FromBody] ContractorForCreateDto contractorForCreateDto)
        {
            var createdContractorGuid = await _service.CreateContractorAsync(contractorForCreateDto);

            return CreatedAtRoute("ContractorById", new { id =  createdContractorGuid });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateContractor(Guid id, [FromBody] ContractorForUpdateDto contractorForUpdateDto)
        {
            await _service.UpdateContractorAsync(id, contractorForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletContractor(Guid id)
        {
            await _service.DeleteContractorAsync(id);

            return NoContent();
        }
    }
}
