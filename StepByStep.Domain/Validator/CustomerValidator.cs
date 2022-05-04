using FluentValidation;
using System;

namespace StepByStep.Domain.Validator
{
    public class CustomerValidator : AbstractValidator <Customer.Customer>
    {
        public CustomerValidator()
        {
            RuleFor(r => r.Id)
                .NotNull()
                .NotEqual(new Guid());

            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Nome não pode ser em branco");

            RuleFor(r => r.Birthday)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.MinValue).LessThan(DateTime.MaxValue).WithMessage("Data de nascimento não pode ser em branco");

            RuleFor(r => r.Rg)
               .NotNull()
               .NotEmpty()
               .MinimumLength(12).MaximumLength(12).WithMessage("Rg deve ter exatamente 12 digitos");

            RuleFor(r => r.Cpf)
                .NotNull()
                .NotEmpty()
                .MinimumLength(14).MaximumLength(14).WithMessage("Cpf deve ter exatamente 14 digitos");

            RuleFor(r => r.RegisterDate)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.MinValue).LessThanOrEqualTo(DateTime.MaxValue).WithMessage("Data de cadastro não pode ser em branco");

            RuleFor(r => r.Active)
                .NotNull()
                .NotEmpty().WithMessage("Cliente deve estar ativo");
        }
    }
}
