using AutoMapper;
using GlowingSystem.Core.ErrorModels.Exceptions;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Models;
using GlowingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlowingSystem.DataAccess.Repositories
{
    public class ContractorRepository : IContractorRepository
    {
        private readonly GlowingSystemDbContext _context;
        private readonly IMapper _mapper;

        public ContractorRepository(GlowingSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> CreateContractorAsync(Contractor contractor)
        {
            var contractorEntity = _mapper.Map<Contractor, ContractorEntity>(contractor);
            _context.Contractors.Add(contractorEntity);
            await _context.SaveChangesAsync();

            return contractorEntity.Id;
        }

        public async Task DeleteContractorAsync(Guid id)
        {
            var contractorEntity = await _context.Contractors.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (contractorEntity == null)
                throw new ContractorNotFoundException(id);

            await _context.Contractors.Where(c => c.Id.Equals(id)).ExecuteDeleteAsync();
        }

        public async Task<Contractor> GetContractorByIdAsync(Guid id)
        {
            var contractorEntity = await _context.Contractors.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (contractorEntity == null)
                throw new ContractorNotFoundException(id);

            var contractor = _mapper.Map<ContractorEntity, Contractor>(contractorEntity);
            return contractor;
        }

        public async Task<IEnumerable<Contractor>?> GetContractorsAsync()
        {
            List<Contractor> contractors = await _context.Contractors.AsNoTracking()
                .Select(contractor => _mapper.Map<ContractorEntity, Contractor>(contractor))
                .ToListAsync();

            return contractors;
        }

        public async Task UpdateContractorAsync(Contractor contractor)
        {
            var contractorEntity = await _context.Contractors.FirstOrDefaultAsync(c => c.Id.Equals(contractor.Id));
            if (contractorEntity == null)
                throw new ContractorNotFoundException(contractor.Id);

            _mapper.Map(contractor, contractorEntity);
            await _context.SaveChangesAsync();
        }
    }
}
