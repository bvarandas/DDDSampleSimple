using DDDSample.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Validations
{
    public class RegisterNewAdvCommandValidation: AdvValidation<RegisterNewAdvCommand>
    {
        public RegisterNewAdvCommandValidation()
        {
            ValidateAno();
            ValidateMarca();
            ValidateModelo();
        }
    }
}
