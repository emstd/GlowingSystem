using GlowingSystem.Core.Models;

namespace GlowingSystem.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>?> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<Guid> CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid id);
    }
}
