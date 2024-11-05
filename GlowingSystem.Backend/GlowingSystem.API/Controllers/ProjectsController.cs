using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlowingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
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
            if (id == Guid.Empty)
                return BadRequest("Invalid project id");

            var project = await _service.GetProjectByIdAsync(id);

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectForCreateDto projectForCreateDto)
        {
            //ActionFilter
            var createdProjectGuid = await _service.CreateProjectAsync(projectForCreateDto);

            return CreatedAtRoute("ProjectById", new { id = createdProjectGuid });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectForUpdateDto projectForUpdateDto)
        {
            //ActionFilter
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
