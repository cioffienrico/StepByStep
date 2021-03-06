using System;

namespace StepByStep.Infrastructure.DataAccess.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Cep { get; set; }
        public string Road { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
