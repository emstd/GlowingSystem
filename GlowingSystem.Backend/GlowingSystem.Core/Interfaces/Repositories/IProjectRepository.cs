using GlowingSystem.Core.Models;

namespace GlowingSystem.Core.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>?> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<Guid> CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Guid id);
    }
}
