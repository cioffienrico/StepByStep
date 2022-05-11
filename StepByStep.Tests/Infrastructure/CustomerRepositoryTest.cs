using FluentAssertions;
using StepByStep.Application.Repositories;
using StepByStep.Tests.Builders;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StepByStep.Test.Infrastructure
{
    [UseAutofacTestFramework]
    public class CustomerRepositoryTest
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerRepositoryTest(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void ShouldAddNewClient()
        {
            var customer = CustomerBuilder.New().Build();
            
            var retorno = customerRepository.AddClient(customer);
            var client = customerRepository.SearchByName(customer.Name);

            retorno.Should().BeTrue();
            client.Should().NotBeNull();
        }

        [Fact]
        public void ShouldUpdateNewClient()
        {
            var customer = CustomerBuilder.New().Build();

            customerRepository.AddClient(customer);
            
            customer = CustomerBuilder.New().WithId(customer.Id).WithName("Teste atualizar").Build();

            var retorno1 = customerRepository.UpdateClient(customer);
            var a = customerRepository.SearchByName("Teste atualizar");

            retorno1.Should().BeTrue();
            a.Should().NotBeNull();
        }
    }
}
