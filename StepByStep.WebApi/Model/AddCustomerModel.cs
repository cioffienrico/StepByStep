using System;
using System.ComponentModel.DataAnnotations;

namespace StepByStep.Webapi.Models
{
    public class AddCustomerModel
    {
        [Required]
        public string Name { get;  set; }

        [Required]
        public DateTime Birthday { get;  set; }

        [Required]
        public string Rg { get;  set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Road { get; set; }

        [Required]
        public string Number { get; set; }

        public string Complement { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }


    }
}
