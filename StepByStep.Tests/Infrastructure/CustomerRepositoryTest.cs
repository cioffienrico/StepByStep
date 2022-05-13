using FluentAssertions;
using StepByStep.Application.Repositories;
using StepByStep.Test.Builders;
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
        public void DeveAdicionarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("223431485").WithCpf("84023371041").Build();

            var retorno = customerRepository.AddClient(customer);
            var client = customerRepository.SearchByName(customer.Name);

            retorno.Should().BeTrue();
            client.Should().NotBeNull();
        }

        [Fact]
        public void DeveAtualizarUmClienteNovoNoBanco()
        {
            var customer = CustomerBuilder.New().WithRg("163785892").WithCpf("55829931001").Build();
            var adress = AdressBuilder.New().WithId(customer.Address.Id).Build();

            customerRepository.AddClient(customer);

            customer = CustomerBuilder.New().WithId(customer.Id).WithName("Teste atualizar").WithAdress(adress).Build();

            var retorno1 = customerRepository.UpdateClient(customer);
            var a = customerRepository.SearchByName("Teste atualizar");

            retorno1.Should().BeTrue();
            a.Should().NotBeNull();
        }
    }
}
