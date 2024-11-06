using GlowingSystem.Core.DataTransferObjects;

namespace GlowingSystem.Core.Interfaces.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>?> GetProjectsAsync();
        Task<ProjectDto> GetProjectByIdAsync(Guid id);
        Task<Guid> CreateProjectAsync(ProjectForCreateDto projectForCreateDto);
        Task UpdateProjectAsync(Guid projectId, ProjectForUpdateDto projectForUpdateDto);
        Task DeleteProjectAsync(Guid id);
    }
}
