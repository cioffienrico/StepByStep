using StepByStep.Application.Repositories;
using StepByStep.Application.UseCases.GetById;
using StepByStep.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StepByStep.Application.UseCases.GetById
{
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public GetByIdUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Customer Execute(GetByIdRequest request)
        {
            var customer = customerRepository.SearchById(request.Id);

            return customer;
        }
    }
}
