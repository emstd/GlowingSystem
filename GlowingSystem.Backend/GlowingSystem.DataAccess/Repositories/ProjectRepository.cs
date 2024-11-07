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
            ProjectEntity projectEntity = new()
            {
                ProjectName = project.ProjectName,
                CustomerId = project.CustomerId,
                ContractorId = project.ContractorId,
                StartDate = project.StartDate,
                Priority = project.Priority,
                Employees = project.Employees == null ? null : await _context.Employees
                    .Where(e => project.Employees.Contains(e.Id))
                    .ToListAsync()
            };

            _context.Projects.Add(projectEntity);
            await _context.SaveChangesAsync();

            return projectEntity.Id;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var projectEntity = await _context.Projects.FindAsync(id);
            if (projectEntity == null)
                throw new Exception();

            await _context.Projects.Where(p => p.Id.Equals(id)).ExecuteDeleteAsync();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            var projectEntity = await _context.Projects.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (projectEntity == null)
                throw new Exception();

            var project = new Project()
            {
                Id = projectEntity.Id,
                ProjectName = projectEntity.ProjectName,
                CustomerId = projectEntity.CustomerId,
                ContractorId = projectEntity.ContractorId,
                StartDate = projectEntity.StartDate,
                EndDate = projectEntity.EndDate,
                Priority = projectEntity.Priority,
                Employees = projectEntity.Employees.Select(e => e.Id).ToList(),
            };

            return project;
        }

        public async Task<IEnumerable<Project>?> GetProjectsAsync()
        {
            //var projectss = await _context.Projects.AsNoTracking().Include(p => p.Employees).ToListAsync();

            List<ProjectEntity> projectss = await _context.Projects.AsNoTracking()
                .Include(p => p.Employees)
                .ToListAsync();

            List<Project> projects = await _context.Projects.AsNoTracking()
                .Include(p => p.Employees)
                .Select(p => new Project
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    CustomerId = p.CustomerId,
                    ContractorId = p.ContractorId,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Priority = p.Priority,
                    Employees = p.Employees.Select(e => e.Id).ToList(),
                })
                .ToListAsync();

            return projects;
        }

        public async Task UpdateProjectAsync(Project project)
        {
            var projectEntity = await _context.Projects.FirstOrDefaultAsync(p => p.Id.Equals(project.Id));
            if (projectEntity == null)
                throw new Exception();

            _mapper.Map(project, projectEntity);
            await _context.SaveChangesAsync();
        }
    }
}
