﻿namespace GlowingSystem.Core.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public required string ProjectName { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ContractorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Guid>? EmployeesIds { get; set; }
    }
}
