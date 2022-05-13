using StepByStep.Domain;
using StepByStep.Test.Builders;
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
        public Address Adress;

        public static CustomerBuilder New()
        {
            return new CustomerBuilder()
            {
                Id = Guid.NewGuid(),
                Name = "Enrico Cioffi Gouveia de Oliveira",
                Birthday = DateTime.Today,
                Rg = "52.238.190-X",
                Cpf = "473.123.378-05",
                RegisterDate = DateTime.Today,
                Active = true,
                Adress = AdressBuilder.New().Build(),

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
        public CustomerBuilder WithAdress(Address adress)
        {
            Adress = adress;
            return this;
        }

        public Customer Build() =>
        
            new Customer(Id, Name, Birthday, Rg, Cpf, RegisterDate, Adress, Active);
        

    }
}
