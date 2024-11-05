using AutoMapper;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Models;
using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlowingSystem.DataAccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly GlowingSystemDbContext _context;
        private readonly IMapper _mapper;
        public ProjectRepository(GlowingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> CreateProject(Project project)
        {
            var projectEntity = _mapper.Map<Project, ProjectEntity>(project);
            await _context.Projects.AddAsync(projectEntity);
            await _context.SaveChangesAsync();

            return projectEntity.Id;
        }

        public async Task<bool> DeleteProject(Guid id)
        {
            var dbProject = await _context.Projects.FindAsync(id);
            if (dbProject == null)
                return false;

            await _context.Projects.Where(p => p.Id == id).ExecuteDeleteAsync();
            return true;
        }

        public Task<Project> GetProjectById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetProjects()
        {
            throw new NotImplementedException();
        }

        public Task<Project?> UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
