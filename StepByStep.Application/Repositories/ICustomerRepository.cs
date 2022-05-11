using StepByStep.Domain.Customer;
using System;
using System.Collections.Generic;

namespace StepByStep.Application.Repositories
{
    public interface ICustomerRepository
    {
        bool AddClient(Customer customer);
        bool AddClients(List<Customer> customers);
        bool UpdateClient(Customer customer);
        List<Customer> GetAll();
        Customer SearchByName(string name);
        Customer SearchById(Guid id);
        Customer SearchClient(string Rg, string Cpf);
        bool DeleteClient(Customer customer);
    }
}
