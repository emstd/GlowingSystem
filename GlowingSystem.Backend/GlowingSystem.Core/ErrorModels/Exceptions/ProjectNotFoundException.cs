using GlowingSystem.Core.Models;

namespace GlowingSystem.Core.ErrorModels.Exceptions
{
    public class ProjectNotFoundException : NotFoundException
    {
        public ProjectNotFoundException(Guid projectId) : base($"Project with id: {projectId} not found.")
        {
            
        }
    }
}
