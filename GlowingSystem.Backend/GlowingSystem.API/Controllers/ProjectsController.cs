using GlowingSystem.API.ActionFilters;
using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GlowingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectService service, ILogger<ProjectsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _service.GetProjectsAsync();

            return Ok(projects);
        }

        [HttpGet("{id:guid}", Name = "ProjectById")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var project = await _service.GetProjectByIdAsync(id);

            return Ok(project);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProject([FromBody] ProjectForCreateDto projectForCreateDto)
        {
            if (projectForCreateDto.EndDate.HasValue && projectForCreateDto.EndDate < projectForCreateDto.StartDate)
            {
                _logger.LogError("The start date cannot be later than the end date.");
                return BadRequest("The start date cannot be later than the end date.");
            }

            var createdProjectGuid = await _service.CreateProjectAsync(projectForCreateDto);

            return Ok(createdProjectGuid);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectForUpdateDto projectForUpdateDto)
        {
            if (projectForUpdateDto.EndDate.HasValue && projectForUpdateDto.EndDate < projectForUpdateDto.StartDate)
            {
                _logger.LogError("The start date cannot be later than the end date.");
                return BadRequest("The start date cannot be later than the end date.");
            }
            await _service.UpdateProjectAsync(id, projectForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _service.DeleteProjectAsync(id);

            return NoContent();
        }
    }
}
