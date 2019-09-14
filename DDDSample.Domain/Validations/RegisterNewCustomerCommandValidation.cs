using DDDSample.Domain.Commands;

namespace DDDSample.Domain.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
