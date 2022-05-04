using FluentValidation.Results;
using StepByStep.Domain.Validator;
using System;


namespace StepByStep.Domain.Customer
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public bool Active { get; private set; }
        
        public ValidationResult Validations { get; set; }


        public Customer(Guid id, string name, DateTime birthday, string rg, string cpf, DateTime registerDate, Boolean active)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;
            RegisterDate = registerDate;
            Active = active;
            Validations = new CustomerValidator().Validate(this);
        }
    }
}
