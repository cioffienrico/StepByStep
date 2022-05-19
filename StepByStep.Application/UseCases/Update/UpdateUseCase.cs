using StepByStep.Application.Repositories;
using StepByStep.Application.UseCases.Update;
using StepByStep.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepByStep.Application.UseCases.Update
{
    public class UpdateUseCase : IUpdateUseCase
    {
        private readonly ICustomerRepository customerRepository;

        public UpdateUseCase(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Execute(UpdateRequest request)
        {
            var customer = customerRepository.GetById(request.Id);

            var customerUpdate = new Customer(customer.Id, request.Name, request.Birthday, request.Rg, request.Cpf, customer.RegisterDate, customer.Active);

            var updated = customerRepository.UpdateClient(customerUpdate);

            return updated;
        }
    }
}
