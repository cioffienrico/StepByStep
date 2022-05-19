using StepByStep.Domain;
using System;
using System.Collections.Generic;

namespace StepByStep.Application.Repositories
{
    public interface ICustomerRepository
    {
        bool AddClient(Customer customer);
        bool AddClients(List<Customer> customers);
        Customer UpdateClient(Customer customer);
        List<Customer> GetAll();
        Customer GetByName(string name);
        Customer GetClient(string cpf, string rg);
        Customer GetById(Guid id);
        int Delete(Guid customerId);
    }
}
