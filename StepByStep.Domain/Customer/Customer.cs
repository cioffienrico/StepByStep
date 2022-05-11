using FluentValidation.Results;
using StepByStep.Domain.Validator;
using System;


namespace StepByStep.Domain.Customer
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Active { get; set; }
        public Adress Adress { get; private set; }
        public Customer(Guid id, string name, DateTime birthday, string rg, string cpf, DateTime registerDate, bool active, Adress adress)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;
            RegisterDate = registerDate;
            Active = active;
            Adress = adress;
            Validate(this, new CustomerValidator());
        }
    }
}
