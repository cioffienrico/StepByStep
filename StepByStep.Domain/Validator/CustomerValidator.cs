using FluentValidation;
using System;

namespace StepByStep.Domain.Validator
{
    public class CustomerValidator : AbstractValidator <Customer>
    {
        public CustomerValidator()
        {
            RuleFor(r => r.Id)
                .NotNull()
                .NotEqual(new Guid());

            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty();                

            RuleFor(r => r.Birthday)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.MinValue).LessThan(DateTime.MaxValue);

            RuleFor(r => r.Rg)
               .NotNull()
               .NotEmpty()
               .MinimumLength(12).MaximumLength(12);

            RuleFor(r => r.Cpf)
                .NotNull()
                .NotEmpty()
                .MinimumLength(14).MaximumLength(14);

            RuleFor(r => r.RegisterDate)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.MinValue).LessThanOrEqualTo(DateTime.MaxValue);

            RuleFor(r => r.Address)
                .NotNull();

            RuleFor(r => r.Active)
                .NotNull()
                .NotEmpty();

            
                

        }
    }
}
