using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StepByStep.Application.Repositories;
using StepByStep.Domain;
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

            context.Customer.Add(customerEntity);
            var i = context.SaveChanges();

            return i > 0;
        }
        public bool AddClients(List<Customer> customers)
        {
            using var context = new Context();
            var customerEntity = mapper.Map<List<Entities.Customer>>(customers);

            context.Customer.AddRange(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }

        public bool UpdateClient(Customer customer)
        {
            using var context = new Context();
            var customerEntity = mapper.Map<Entities.Customer>(customer);

            context.Customer.Update(customerEntity);

            var i = context.SaveChanges();

            return i > 0;
        }

        public Customer GetClient(string rg, string cpf)
        {
            using var context = new Context();
            var customer = context.Customer
                .Where(w => w.Cpf.Equals(cpf) || w.Rg.Equals(rg))
                .Include(s=>s.Address)
                .FirstOrDefault();

            return mapper.Map<Customer>(customer);
        }
         //&& w.Active
        public Customer GetByName(string nome)
        {
            using var context = new Context();
            var customer = context.Customer
                .Where(w => w.Name == nome)
                .Include(s => s.Address)                
                .FirstOrDefault();

            return mapper.Map<Customer>(customer);
        }

        public Customer GetById(Guid id)
        {
            using var context = new Context();

            var customer = context.Customer
                .Where(w => w.Id == id)
                .Include(s => s.Address)
                .FirstOrDefault();

            return mapper.Map<Customer>(customer);
        }

        public List<Customer> GetAll()
        {
            using var context = new Context();
            var customers = context.Customer.Include(s => s.Address).ToList();            

            return mapper.Map<List<Customer>>(customers);
        }

        public int Delete(Guid customerId)
        {
            using (Context context = new Context())
            {
                var model = mapper.Map<Entities.Customer>(context.Customer.Where(w => w.Id == customerId).FirstOrDefault());

                context.Customer.Remove(model);
                return context.SaveChanges();
            }
        }


    }
    }

