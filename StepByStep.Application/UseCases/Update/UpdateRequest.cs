using StepByStep.Domain;
using StepByStep.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Update
{
    public class UpdateRequest
    {
        public Guid Id { get; private set; }    
        public string FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public string Cep { get; private set; }
        public string Road { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Adress Adress { get; set; }
        public Customer Customer { get; set; }

        public UpdateRequest(Guid id, string fullName, DateTime birthday, string rg, string cpf, string cep, string road, string number, string complement, string neighborhood, string city, string state)
        {
            Id = id;
            FullName = fullName;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;
            Cep = cep;
            Road = road;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;






        }

    }
}
