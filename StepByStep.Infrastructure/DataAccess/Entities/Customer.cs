using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Infrastructure.DataAccess.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Ativo { get; set; }

    }
}
