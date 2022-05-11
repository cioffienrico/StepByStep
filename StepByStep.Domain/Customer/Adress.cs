using FluentValidation.Results;
using StepByStep.Domain.Validations;
using System;

namespace StepByStep.Domain
{
    public class Adress
    {
        public Guid Id { get; private set; }
        public string Cep { get; private set; }
        public string Road { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public ValidationResult Validations { get; set; }

        public Adress(Guid id, string cep, string road, string number, string complement, string neighborhood, string city, string state)
        {
            Id = id;
            Cep = cep;
            Road = road;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;

            Validations = new AdressValidator().Validate(this);
        }
    }
}
