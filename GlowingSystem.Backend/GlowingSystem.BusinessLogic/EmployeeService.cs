using AutoMapper;
using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Interfaces.Services;
using GlowingSystem.Core.Models;

namespace GlowingSystem.BusinessLogic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateEmployeeAsync(EmployeeForCreateDto employeeForCreateDto)
        {
            var employee = _mapper.Map<EmployeeForCreateDto, Employee>(employeeForCreateDto);
            return await _repository.CreateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _repository.DeleteEmployeeAsync(id);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            var employeeDto = _mapper.Map<Employee, EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDto>?> GetEmployeesAsync()
        {
            var employees = await _repository.GetEmployeesAsync();
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return employeesDto;
        }

        public async Task UpdateEmployeeAsync(Guid employeeId, EmployeeForUpdateDto employeeForUpdateDto)
        {
            var employee = _mapper.Map<EmployeeForUpdateDto, Employee>(employeeForUpdateDto);
            employee.Id = employeeId;

            await _repository.UpdateEmployeeAsync(employee);
        }
    }
}
