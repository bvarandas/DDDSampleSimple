using DDDSample.Domain.Commands;

namespace DDDSample.Domain.Validations
{
    public class RemoveCustomerCommandValidation: CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}
