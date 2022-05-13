using FluentAssertions;
using StepByStep.Application.Repositories;
using StepByStep.Application.UseCases.Add;
using StepByStep.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StepByStep.Test.Application.UseCases.Add
{
    [UseAutofacTestFramework]
    public class AddUseCaseTest
    {
        private readonly IAddUseCase addUseCase;
        private readonly ICustomerRepository customerRepository;

        public AddUseCaseTest(IAddUseCase addUseCase, ICustomerRepository customerRepository)
        {
            this.addUseCase = addUseCase;
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void DeveAdicionarUmCliente()
        {
            var request = new AddRequest("Enrico", new DateTime(1999, 6, 09), "52.238.190-X", "473.123.378-05", "06026000", "Rua Victor Brecheret", "520", "T8 8D", "Vila Yara", "Osasco", "São Paulo");

            addUseCase.Execute(request);

            var cliente = customerRepository.SearchClient(request.Rg, request.Cpf);

            request.Erros.Should().BeNullOrEmpty();

            cliente.Should().NotBeNull();
            cliente.Name.Should().Be(request.Name);
            cliente.Birthday.Should().Be(request.Birthday);
            cliente.Rg.Should().Be(request.Rg);
            cliente.Cpf.Should().Be(request.Cpf);
        }

        [Fact]
        public void NaoDeveAdicionarUmClienteSemNome()
        {
            var request = new AddRequest("", new DateTime(1999, 6, 09), "52.238.190-X", "473.123.378-05", "06026000", "Rua Victor Brecheret", "520", "T8 8D", "Vila Yara", "Osasco", "São Paulo");

            addUseCase.Execute(request);

            var cliente = customerRepository.SearchClient(request.Rg, request.Cpf);

            request.Erros.Should().NotBeNullOrEmpty().And.HaveCountGreaterThanOrEqualTo(1);

            cliente.Should().BeNull();
        }

        [Fact]
        public void NaoDeveAdicionarUmClienteQueJaExiste()
        {

            var clienteExistente = CustomerBuilder.New().WithCpf("860.868.860-32").WithRg("44.774.404-5").Build();
            customerRepository.AddClient(clienteExistente);

            var request = new AddRequest("", new DateTime(1993, 5, 27), "", "860.868.860-32", "04571936", "Av. Engenheiro Luís Carlos Berrini", "1376", "", "Cidade Monções", "São Paulo", "São Paulo");

            addUseCase.Execute(request);

            var cliente = customerRepository.SearchClient(request.Rg, request.Cpf);

            request.Erros.Should().NotBeNullOrEmpty().And.Contain("Já existe um cliente com esse rg: " + request.Rg + ", ou com esse cpf: " + request.Cpf);

            cliente.Should().NotBeNull();
        }
    }
}
