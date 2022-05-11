using StepByStep.Application.Repositories;
using StepByStep.Application.UseCases.Add;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Add.RequestHandlers
{
    public class SaveCustomerHandler : Handler<AddRequest>
    {
        private readonly ICustomerRepository customerRepository;

        public SaveCustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public override void ProcessRequest(AddRequest request)
        {
            customerRepository.AddClient(request.Customer);

            sucessor?.ProcessRequest(request);
        }
    }
}
