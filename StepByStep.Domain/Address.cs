using FluentValidation.Results;
using StepByStep.Domain.Validations;
using System;

namespace StepByStep.Domain
{
    public class Address : Entity
    {
        public Guid CustomerId { get; set; }
        public string Cep { get; private set; }
        public string Road { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public virtual Customer Customer { get; private set; }
    public Address(Guid id, Guid customerId, string cep, string road, string number, string complement, string neighborhood, string city, string state)
        {
            Id = id;
            CustomerId = customerId;
            Cep = cep;
            Road = road;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Validate(this, new AddressValidator());
        }
    }
}
