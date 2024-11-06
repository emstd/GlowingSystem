using GlowingSystem.Core.DataTransferObjects;

namespace GlowingSystem.Core.Interfaces.Services
{
    public interface IContractorService
    {
        Task<IEnumerable<ContractorDto>?> GetContractorsAsync();
        Task<ContractorDto> GetContractorByIdAsync(Guid id);
        Task<Guid> CreateContractorAsync(ContractorForCreateDto contractorForCreateDto);
        Task UpdateContractorAsync(Guid contractorId, ContractorForUpdateDto contractorForUpdateDto);
        Task DeleteContractorAsync(Guid id);
    }
}
