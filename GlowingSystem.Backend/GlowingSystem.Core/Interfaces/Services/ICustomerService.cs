using GlowingSystem.Core.DataTransferObjects;

namespace GlowingSystem.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>?> GetCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(Guid id);
        Task<Guid> CreateCustomerAsync(CustomerForCreateDto customerForCreateDto);
        Task UpdateCustomerAsync(Guid customerId, CustomerForUpdateDto customerForUpdateDto);
        Task DeleteCustomerAsync(Guid id);
    }
}
