namespace GlowingSystem.DataAccess.Entities
{
    public class EmployeeProject
    {
        public Guid ProjectId { get; set; }
        public ProjectEntity Project { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; } = null!;
    }
}
