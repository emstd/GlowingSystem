namespace GlowingSystem.Core.DataTransferObjects
{
    public record EmployeeWithProjectsDto : EmployeeDto
    {
        public List<ProjectDto>? Projects { get; set; }
    }
}
