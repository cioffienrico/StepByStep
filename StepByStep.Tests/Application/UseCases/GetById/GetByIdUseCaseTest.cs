using FluentAssertions;
using StepByStep.Application.Repositories;
using StepByStep.Application.UseCases.GetById;
using StepByStep.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace StepByStep.Tests.Application.UseCases.GetById
{
    [UseAutofacTestFramework]
    public class GetByIdUseCaseTest
    {
        private readonly IGetByIdUseCase getByIdUseCase;
        private readonly ICustomerRepository customerRepository;

        public GetByIdUseCaseTest(IGetByIdUseCase getByIdUseCase, ICustomerRepository customerRepository)
        {
            this.getByIdUseCase = getByIdUseCase;
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void DeveBuscarPorId()
        {
            var cliente = CustomerBuilder.New().Build();

            customerRepository.AddClient(cliente);

            var request = new GetByIdRequest(cliente.Id);

            var a = getByIdUseCase.Execute(request);

            a.Should().NotBeNull();

        }
    }
}
