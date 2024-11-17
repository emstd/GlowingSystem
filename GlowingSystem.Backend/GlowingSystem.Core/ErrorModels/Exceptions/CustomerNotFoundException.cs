namespace GlowingSystem.Core.ErrorModels.Exceptions
{
    public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(Guid customerId) : base($"Customer with ID: {customerId} was not found.")
        {
            
        }
    }
}
