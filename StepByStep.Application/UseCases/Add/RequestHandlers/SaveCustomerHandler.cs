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
        private readonly IAddressRepository addressRepository;

        public SaveCustomerHandler(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            this.customerRepository = customerRepository;
            this.addressRepository = addressRepository;
        }

        public override void ProcessRequest(AddRequest request)
        {            
            customerRepository.AddClient(request.Customer);
            addressRepository.Add(request.Address);

            sucessor?.ProcessRequest(request);
        }
    }
}
