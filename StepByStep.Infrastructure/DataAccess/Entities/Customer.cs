using StepByStep.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual Address Address { get; set; }
        public bool Active { get; set; }

    }
}
