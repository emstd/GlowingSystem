using AutoMapper;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Models;
using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlowingSystem.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GlowingSystemDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(GlowingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> CreateEmployeeAsync(Employee employee)
        {
            var employeeEntity = _mapper.Map<Employee, EmployeeEntity>(employee);
            _context.Employees.Add(employeeEntity);
            await _context.SaveChangesAsync();

            return employeeEntity.Id;
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employeeEntity = _context.Employees.FirstOrDefault(e => e.Id.Equals(id));
            if (employeeEntity == null)
                throw new Exception();

            await _context.Employees.Where(e => e.Id.Equals(id)).ExecuteDeleteAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            var employeeEntity = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(id));
            if (employeeEntity == null)
                throw new Exception();

            return _mapper.Map<EmployeeEntity, Employee>(employeeEntity);
        }

        public async Task<IEnumerable<Employee>?> GetEmployeesAsync()
        {
            List<Employee> employees = await _context.Employees.AsNoTracking().Include(e => e.Projects)
                .Select(e => _mapper.Map<EmployeeEntity, Employee>(e))
                .ToListAsync();

            return employees;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var employeeEntity = await _context.Employees.FirstOrDefaultAsync(e => e.Id.Equals(employee.Id));
            if (employeeEntity == null)
                throw new Exception();

            _mapper.Map(employee, employeeEntity);
            await _context.SaveChangesAsync();
        }
    }
}
