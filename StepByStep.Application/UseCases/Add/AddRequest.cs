using StepByStep.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Add
{
    public class AddRequest
    {
        public string Name { get; private set; }
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
        public Address Address { get; set; }
        public Customer Customer { get; set; }
        public List<string> Erros { get; set; }

        public AddRequest(string name, DateTime birthday, string rg, string cpf, string cep, string road, string number, string complement, string neighborhood, string city, string state)
        {
            Name = name;
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
            Erros = new List<string>();



        }

    }
}