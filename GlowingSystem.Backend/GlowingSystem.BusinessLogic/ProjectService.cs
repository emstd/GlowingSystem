using AutoMapper;
using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Interfaces.Services;
using GlowingSystem.Core.Models;

namespace GlowingSystem.BusinessLogic
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateProjectAsync(ProjectForCreateDto projectForCreateDto)
        {
            var project = _mapper.Map<ProjectForCreateDto, Project>(projectForCreateDto);

            return await _repository.CreateProjectAsync(project);
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await _repository.DeleteProjectAsync(id);
        }

        public async Task<ProjectDto> GetProjectByIdAsync(Guid id)
        {
            var project = await _repository.GetProjectByIdAsync(id);
            var projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;
        }

        public async Task<IEnumerable<ProjectDto>?> GetProjectsAsync()
        {
            var projects = await _repository.GetProjectsAsync();
            var projectsDto = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            
            return projectsDto;
        }

        public async Task UpdateProjectAsync(Guid projectId, ProjectForUpdateDto projectForUpdateDto)
        {
            var project = _mapper.Map<ProjectForUpdateDto, Project>(projectForUpdateDto);
            project.Id = projectId;

            await _repository.UpdateProjectAsync(project);
        }
    }
}
