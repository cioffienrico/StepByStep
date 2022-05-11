using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepByStep.Application.Repositories;
using StepByStep.Domain.Customer;
using StepByStep.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StepByStep.Infrastructure.DataAccess.Repositorios
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMapper mapper;

        public CustomerRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public bool AddClient(Customer customer)
        {
            using var context = new Context();
            var customerEntity = mapper.Map<Entities.Customer>(customer);

            context.Customers.Add(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }
        public bool AddClients(List<Customer> customers)
        {
            using var context = new Context();
            var customerEntity = mapper.Map<List<Entities.Customer>>(customers);

            context.Customers.AddRange(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }

        public bool UpdateClient(Customer customer)
        {
            using var context = new Context();
            var customerEntity = mapper.Map<Entities.Customer>(customer);

            context.Customers.Update(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }

        public Customer SearchClient(string rg, string cpf)
        {
            using var context = new Context();
            var cliente = context.Customers.Where(w => (w.Cpf.Equals(cpf) || w.Rg.Equals(rg)) && w.Active).FirstOrDefault();

            return mapper.Map<Customer>(cliente);
        }

        public Customer SearchByName(string nome)
        {
            using var context = new Context();
            var cliente = context.Customers
                .Where(w => w.Name == nome).FirstOrDefault();

            return mapper.Map<Customer>(cliente);
        }

        public Customer SearchById(Guid id)
        {
            using var context = new Context();

            var customer = context.Customers
                .Where(w => w.Id == id).FirstOrDefault();

            return mapper.Map<Customer>(customer);
        }

        public List<Customer> GetAll()
        {
            using var context = new Context();
            var customers = context.Customers.ToList();

            return mapper.Map<List<Customer>>(customers);
        }

        public bool DeleteClient(Customer customer)
        {
            using var context = new Context();

            var remover = context.Customers.Where(w => w.Id == customer.Id).FirstOrDefault();

            context.Customers.Remove(remover);

            var i = context.SaveChanges();

            return i > 0;
        }

        }
    }

