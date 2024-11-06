using AutoMapper;
using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Interfaces.Services;
using GlowingSystem.Core.Models;

namespace GlowingSystem.BusinessLogic
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateCustomerAsync(CustomerForCreateDto customerForCreateDto)
        {
            var customerEntity = _mapper.Map<CustomerForCreateDto, Customer>(customerForCreateDto);

            return await _repository.CreateCustomerAsync(customerEntity);
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            await _repository.DeleteCustomerAsync(id);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _repository.GetCustomerByIdAsync(id);
            var customerDto = _mapper.Map<Customer, CustomerDto>(customer);

            return customerDto;
        }

        public async Task<IEnumerable<CustomerDto>?> GetCustomersAsync()
        {
            var customers = await _repository.GetCustomersAsync();
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return customersDto;
        }

        public async Task UpdateCustomerAsync(Guid customerId, CustomerForUpdateDto customerForUpdateDto)
        {
            var customer = _mapper.Map<CustomerForUpdateDto, Customer>(customerForUpdateDto);
            customer.Id = customerId;

            await _repository.UpdateCustomerAsync(customer);
        }
    }
}
