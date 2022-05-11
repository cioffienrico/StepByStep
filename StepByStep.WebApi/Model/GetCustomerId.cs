using System;
using System.ComponentModel.DataAnnotations;

namespace StepByStep.Webapi.Models
{
    public class GetCustomerIdInput
    {
        [Required]
        public Guid CustomerId { get; set; }

    }
}
