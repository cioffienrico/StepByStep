using System;
using System.ComponentModel.DataAnnotations;

namespace StepByStep.Webapi.Models
{
    public class GetCustomerModel
    {

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string Road { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }


        public GetCustomerModel(string name, DateTime birthday, string rg, string cpf, string cep, string road, string number, string complement, string neighborhood, string city, string state)
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
        }

    }
}
