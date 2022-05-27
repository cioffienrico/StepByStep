using StepByStep.Application.Repositories;
using StepByStep.Application.UseCases.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Update.Handlers
{
    public class SaveUpdatedCustomerHandler : Handler<UpdateRequest>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IAddressRepository addressRepository;

        public SaveUpdatedCustomerHandler(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            this.customerRepository = customerRepository;
            this.addressRepository = addressRepository;
        }

        public override void ProcessRequest(UpdateRequest request)
        {            
            customerRepository.UpdateClient(request.Customer);
            addressRepository.Update(request.Address);

            sucessor?.ProcessRequest(request);
        }
    }
}
