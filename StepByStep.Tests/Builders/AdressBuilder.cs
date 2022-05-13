using StepByStep.Domain;
using System;

namespace StepByStep.Test.Builders
{
    public class AdressBuilder
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


        public static AdressBuilder New()
        {
            return new AdressBuilder()
            {
                Id = Guid.NewGuid(),
                Cep = "06026000",
                Road = "Victor Brecheret",
                Number = "520",
                Complement = "T8 8D",
                Neighborhood = "Vila Yara",
                City = "Osasco",
                State = "São Paulo",
            };
        }

        public AdressBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }
        public AdressBuilder WithCep(string cep)
        {
            Cep = cep;
            return this;
        }

        public AdressBuilder WithRoad(string road)
        {
            Road = road;
            return this;
        }

        public AdressBuilder WithNumber(string number)
        {
            Number = number;
            return this;
        }

        public AdressBuilder WithComplement(string complement)
        {
            Complement = complement;
            return this;
        }

        public AdressBuilder WithNeighborhood(string neighborhood)
        {
            Neighborhood = neighborhood;
            return this;
        }

        public AdressBuilder WithCity(string city)
        {
            City = city;
            return this;
        }

        public AdressBuilder WithState(string state)
        {
            State = state;
            return this;
        }

        public Address Build() => new Address(Id, Cep, Road, Number, Complement, Neighborhood, City, State);

    }
}
