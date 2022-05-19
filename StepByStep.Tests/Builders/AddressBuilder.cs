using StepByStep.Domain;
using System;

namespace StepByStep.Tests.Builders
{
    public class AddressBuilder
    {
        public Guid Id;
        public Guid CustomerId;
        public string Cep;
        public string Road;
        public string Number;
        public string Complement;
        public string Neighborhood;
        public string City;
        public string State;


        public static AddressBuilder New()
        {
            return new AddressBuilder()
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                Cep = "06026000",
                Road = "Victor Brecheret",
                Number = "520",
                Complement = "T8 8D",
                Neighborhood = "Vila Yara",
                City = "Osasco",
                State = "São Paulo",
            };
        }

        public AddressBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public AddressBuilder WithCustomerId(Guid customerId)
        {
            CustomerId = customerId;
            return this;
        }
        public AddressBuilder WithCep(string cep)
        {
            Cep = cep;
            return this;
        }

        public AddressBuilder WithRoad(string road)
        {
            Road = road;
            return this;
        }

        public AddressBuilder WithNumber(string number)
        {
            Number = number;
            return this;
        }

        public AddressBuilder WithComplement(string complement)
        {
            Complement = complement;
            return this;
        }

        public AddressBuilder WithNeighborhood(string neighborhood)
        {
            Neighborhood = neighborhood;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            City = city;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            State = state;
            return this;
        }

        public Address Build() => new Address(Id, CustomerId, Cep, Road, Number, Complement, Neighborhood, City, State);

    }
}
