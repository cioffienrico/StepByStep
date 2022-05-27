using FluentAssertions;
using StepByStep.Application.Repositories;
using StepByStep.Infrastructure;
using StepByStep.Tests.Builders;
using StepByStep.Tests.TestCaseOrdering;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StepByStep.Tests.Infrastructure
{
    [TestCaseOrderer("StepByStep.Tests.TestCaseOrdering.PriorityOrderer", "StepByStep.Tests")]
    [UseAutofacTestFramework]
    public class CustomerRepositoryTest
    {
        private readonly ICustomerRepository customerRepository;
        private static Guid Id1;
        private static string Id2;
        public CustomerRepositoryTest(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        [Fact]
        [TestPriority(0)]
        public void DeveAdicionarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().Build();
            Id1 = customer.Id;
            Id2 = customer.Name;
            var retorno = customerRepository.AddClient(customer);

            retorno.Should().BeTrue();
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetCustomerById()
        {
            var result = customerRepository.GetById(Id1);

            result.Should().NotBeNull();
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetCustomerByName()
        {
            var result = customerRepository.GetByName(Id2);

            result.Should().NotBeNull();
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetAllCustomers()
        {
            var customers = customerRepository.GetAll();
            customers.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateCustomer()
        {
            var customer = CustomerBuilder.New().WithId(Id1).WithName("Wellington").Build();
            var result = customerRepository.UpdateClient(customer);

            result.Should().BeTrue();
        }

        [Fact]
        [TestPriority(3)]
        public void ShouldDeleteAccountDetail()
        {
            int result = customerRepository.Delete(Id1);

            result.Should().BeGreaterThan(0);
        }

    }
}
