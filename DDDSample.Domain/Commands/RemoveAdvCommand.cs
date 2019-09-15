using System;
using DDDSample.Domain.Validations;

namespace DDDSample.Domain.Commands
{
    public class RemoveAdvCommand : AdvCommand
    {
        public RemoveAdvCommand(int id)
        {
            ID = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveAdvCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
