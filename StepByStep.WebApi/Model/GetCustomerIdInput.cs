using System;
using System.ComponentModel.DataAnnotations;

namespace StepByStep.Webapi.Model
{
    public class GetCustomerIdInput
    {
        [Required]
        public Guid CustomerId { get; set; }

    }
}
