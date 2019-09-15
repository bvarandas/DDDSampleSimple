using System;
using DDDSample.Domain.Commands;
using FluentValidation;

namespace DDDSample.Domain.Validations
{
    public abstract class AdvValidation<T> : AbstractValidator<T> where T : AdvCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.ID)
                .NotEqual(0);
        }

        protected void ValidateMarca()
        {
            RuleFor(c => c.Marca)
                .NotEmpty().WithMessage("É necessário inserir a marca do veículo!")
                .Length(2, 150).WithMessage("É necessário inserir ao menos 2 caracteres na marca do veículo!"); 
        }

        protected void ValidateModelo()
        {
            RuleFor(c => c.Modelo)
                .NotEmpty()
                .WithMessage("É necessário inserir a o modelo do veículo!")
                .Length(1, 150).WithMessage("É necessário inserir ao menos 1 caracter no modelo do veículo!");
        }

        protected void ValidateAno()
        {
            RuleFor(c => c.Ano)
                .NotEqual(0)
                .WithMessage("É necessário inserir o ano de fabricação do veículo!");
        }
    }
}
