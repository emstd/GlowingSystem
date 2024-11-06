using GlowingSystem.Core.Models;

namespace GlowingSystem.Core.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>?> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Guid> CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
