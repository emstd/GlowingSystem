using GlowingSystem.Core.Models;

namespace GlowingSystem.Core.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjects();
        Task<Project> GetProjectById(Guid id);
        Task<Guid> CreateProject(Project project);
        Task<Project?> UpdateProject(Project project);
        Task<bool> DeleteProject(Guid id);
    }
}
