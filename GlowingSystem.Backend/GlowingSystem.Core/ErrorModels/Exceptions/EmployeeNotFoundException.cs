namespace GlowingSystem.Core.ErrorModels.Exceptions
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(Guid employeeId) : base($"Employee with id: {employeeId} not found.")
        {
            
        }
    }
}
