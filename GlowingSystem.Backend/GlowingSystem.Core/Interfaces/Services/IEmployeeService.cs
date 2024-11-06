using GlowingSystem.Core.DataTransferObjects;

namespace GlowingSystem.Core.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>?> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<Guid> CreateEmployeeAsync(EmployeeForCreateDto employeeForCreateDto);
        Task UpdateEmployeeAsync(Guid employeeId, EmployeeForUpdateDto employeeForUpdateDto);
        Task DeleteEmployeeAsync(Guid id);
    }
}
