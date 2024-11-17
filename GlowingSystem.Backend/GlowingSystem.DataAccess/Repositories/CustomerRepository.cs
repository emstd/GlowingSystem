using AutoMapper;
using GlowingSystem.Core.ErrorModels.Exceptions;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Models;
using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlowingSystem.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GlowingSystemDbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(GlowingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> CreateCustomerAsync(Customer customer)
        {
            var customerEntity = _mapper.Map<Customer, CustomerEntity>(customer);
            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            return customerEntity.Id;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customerEntity = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (customerEntity == null)
                throw new CustomerNotFoundException(id);

            await _context.Customers.Where(c => c.Id.Equals(id)).ExecuteDeleteAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            var customerEntity = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (customerEntity == null)
                throw new CustomerNotFoundException(id);

            var customer = _mapper.Map<CustomerEntity, Customer>(customerEntity);
            return customer;
        }

        public async Task<IEnumerable<Customer>?> GetCustomersAsync()
        {
            List<Customer> customers = await _context.Customers.AsNoTracking()
                .Select(customer => _mapper.Map<CustomerEntity, Customer>(customer))
                .ToListAsync();

            return customers;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var customerEntity = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(customer.Id));
            if (customerEntity == null)
                throw new CustomerNotFoundException(customer.Id);

            _mapper.Map(customer, customerEntity);
            await _context.SaveChangesAsync();
        }
    }
}
