namespace GlowingSystem.Core.ErrorModels.Exceptions
{
    public sealed class ContractorNotFoundException : NotFoundException
    {
        public ContractorNotFoundException(Guid contractorId) : base($"Contractor with ID: {contractorId} was not found.")
        {
            
        }
    }
}
