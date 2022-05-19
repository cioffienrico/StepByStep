using FluentValidation.Results;
using StepByStep.Domain.Validator;
using System;


namespace StepByStep.Domain
{
    public class Customer : Entity
    {        
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public bool Active { get; private set; }
        public virtual Address Address { get; set; }        
        public Customer(Guid id, string name, DateTime birthday, string rg, string cpf, DateTime registerDate, bool active)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;
            RegisterDate = registerDate;
            Active = active;
            
            Validate(this, new CustomerValidator());
        }
    }
}
