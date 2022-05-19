using FluentValidation;
using StepByStep.Domain;
using System;

namespace StepByStep.Domain.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {    
        public AddressValidator()
        {
            RuleFor(r => r.Id).NotEqual(new Guid()); //00000000-0000-0000-0000-000000000000
            RuleFor(r => r.CustomerId).NotEqual(new Guid()); //00000000-0000-0000-0000-000000000000
            RuleFor(r => r.Cep).NotEmpty().NotNull().MinimumLength(8).MaximumLength(8).WithMessage("Cep não pode ser em branco e deve ter 8 caracteres");
            RuleFor(r => r.Road).NotEmpty().NotNull().WithMessage("Rua não pode ser em branco");
            RuleFor(r => r.Number).NotEmpty().NotNull().WithMessage("Numero não pode ser em branco");
            RuleFor(r => r.Neighborhood).NotEmpty().NotNull().WithMessage("Bairro não pode ser em branco");
            RuleFor(r => r.City).NotEmpty().NotNull().WithMessage("Cidade não pode ser em branco");
            RuleFor(r => r.State).NotEmpty().NotNull().WithMessage("Estado não pode ser em branco");
        }    
    }
}
