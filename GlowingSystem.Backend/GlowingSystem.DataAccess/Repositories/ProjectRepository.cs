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
        public async Task<Guid> CreateProjectAsync(Project project)
        {
            var projectEntity = _mapper.Map<Project, ProjectEntity>(project);
            await _context.Projects.AddAsync(projectEntity);
            await _context.SaveChangesAsync();

            return projectEntity.Id;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var dbProject = await _context.Projects.FindAsync(id);
            if (dbProject == null)
                throw new Exception();

            await _context.Projects.Where(p => p.Id.Equals(id)).ExecuteDeleteAsync();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            var project = await _context.Projects.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (project == null)
                throw new Exception();

            return _mapper.Map<Project>(project);
        }

        public async Task<IEnumerable<Project>?> GetProjectsAsync()
        {
            List<Project> projects = await _context.Projects.AsNoTracking()
                .Select(project => 
                   _mapper.Map<ProjectEntity, Project>(project))
                .ToListAsync();

            if (projects.Count == 0)
                return null;

            return projects;
        }

        public async Task UpdateProjectAsync(Project project)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id.Equals(project.Id));
            if (dbProject == null)
                throw new Exception();

            dbProject = _mapper.Map<Project, ProjectEntity>(project);
            _context.Update(dbProject);
            await _context.SaveChangesAsync();
        }
    }
}
