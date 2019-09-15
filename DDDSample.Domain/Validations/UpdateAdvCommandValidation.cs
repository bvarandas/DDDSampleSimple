using DDDSample.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Validations
{
    public class UpdateAdvCommandValidation : AdvValidation<UpdateAdvCommand>
    {
        public UpdateAdvCommandValidation()
        {
            ValidateAno();
            ValidateId();
            ValidateMarca();
            ValidateModelo();
        }
    }
}
