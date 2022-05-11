using StepByStep.Application.Repositories;
using StepByStep.Application.UseCases.Update;
using StepByStep.Domain.Customer;
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

        public bool Execute(UpdateRequest request)
        {
            var customer = customerRepository.SearchById(request.Id);

            if (customer == null)
                return false;

            var customerUpdate = new Customer(customer.Id, request.FullName, request.Birthday, request.Rg, request.Cpf, customer.RegisterDate, customer.Active, customer.Adress);

            var updated = customerRepository.UpdateClient(customerUpdate);

            return updated;
        }
    }
}
