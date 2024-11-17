using AutoMapper;
using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.ErrorModels.Exceptions;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Interfaces.Services;
using GlowingSystem.Core.Models;

namespace GlowingSystem.BusinessLogic
{
    public class ContractorService : IContractorService
    {
        private readonly IContractorRepository _repository;
        private readonly IMapper _mapper;

        public ContractorService(IContractorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateContractorAsync(ContractorForCreateDto contractorForCreateDto)
        {
            var contractor = _mapper.Map<ContractorForCreateDto, Contractor>(contractorForCreateDto);

            return await _repository.CreateContractorAsync(contractor);
        }

        public async Task DeleteContractorAsync(Guid id)
        {
            await _repository.DeleteContractorAsync(id);
        }

        public async Task<ContractorDto> GetContractorByIdAsync(Guid id)
        {
            var contractor = await _repository.GetContractorByIdAsync(id);
            var contractorDto = _mapper.Map<Contractor, ContractorDto>(contractor);

            return contractorDto;
        }

        public async Task<IEnumerable<ContractorDto>?> GetContractorsAsync()
        {
            var contractors = await _repository.GetContractorsAsync();
            var contractorsDto = _mapper.Map<IEnumerable<ContractorDto>>(contractors);

            return contractorsDto;
        }

        public async Task UpdateContractorAsync(Guid contractorId, ContractorForUpdateDto contractorForUpdateDto)
        {
            var contractor = _mapper.Map<ContractorForUpdateDto, Contractor>(contractorForUpdateDto);
            contractor.Id = contractorId;

            await _repository.UpdateContractorAsync(contractor);
        }
    }
}
