using GlowingSystem.Core.Models;

namespace GlowingSystem.Core.Interfaces.Repositories
{
    public interface IContractorRepository
    {
        Task<IEnumerable<Contractor>?> GetContractorsAsync();
        Task<Contractor> GetContractorByIdAsync(Guid id);
        Task<Guid> CreateContractorAsync(Contractor contractor);
        Task UpdateContractorAsync(Contractor contractor);
        Task DeleteContractorAsync(Guid id);
    }
}
