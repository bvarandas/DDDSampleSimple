using DDDSample.Domain.Commands;

namespace DDDSample.Domain.Validations
{
    public class RemoveAdvCommandValidation : AdvValidation<RemoveAdvCommand>
    {
        public RemoveAdvCommandValidation()
        {
            ValidateId();
        }
    }
}
