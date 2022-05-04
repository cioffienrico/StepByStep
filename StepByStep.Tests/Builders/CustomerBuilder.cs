using StepByStep.Domain.Customer;
using System;

namespace StepByStep.Tests.Builders
{
    public class CustomerBuilder
    {

        public Guid Id;
        public string Name;
        public DateTime Birthday;
        public string Rg;
        public string Cpf;
        public DateTime RegisterDate;
        public bool Active;

        public static CustomerBuilder New()
        {
            return new CustomerBuilder()
            {
                Id = Guid.NewGuid(),
                Name = "Enrico Cioffi Gouveia de Oliveira",
                Birthday = new DateTime(1999, 06, 09),
                Rg = "52.238.190-X",
                Cpf = "473.123.378-05",
                RegisterDate = new DateTime(02, 05, 2020),
                Active = true

        };
        }

        public CustomerBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public CustomerBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public CustomerBuilder WithBirthday(DateTime birthday)
        {
            Birthday = birthday;
            return this;
        }

        public CustomerBuilder WithRg(string rg)
        {
            Rg = rg;
            return this;
        }

        public CustomerBuilder WithCpf(string cpf)
        {
            Cpf = cpf;
            return this;
        }

        public CustomerBuilder WithRegisterDate(DateTime registerDate)
        {
            RegisterDate = registerDate;
            return this;
        }

        public CustomerBuilder WithActive(bool active)
        {
            Active = active;
            return this;
        }


        public Customer Build()
        {
            return new Customer(Id, Name, Birthday, Rg, Cpf, RegisterDate, Active);
        }

    }
}
