using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.GetAll
{
    public class GetAllRequest
    {
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public List<string> ListaCliente { get; set; }
        
        public GetAllRequest(string name, DateTime birthday, string rg, string cpf)
        {
            Name = name;
            Birthday = birthday;
            Rg = rg;
            Cpf = cpf;           
            ListaCliente = new List<string>();
        }

    }
}
