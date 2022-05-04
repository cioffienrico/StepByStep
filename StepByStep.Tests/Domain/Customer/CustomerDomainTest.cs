using StepByStep.Tests.Builders;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StepByStep.Tests.Domain.Customer
{
    public class CustomerDomainTest
    {

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyFullname(string name)
        {
            var customer = CustomerBuilder.New().WithName(name).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void NotCreateWithLessThanMinimumBirthday()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MinValue).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void NotCreateWithMoreThanMaximumBirthday()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MaxValue).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("aaaaaaaaaaaaaaaa")]
        [InlineData("aaaaaaaaaaaaaa")]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithNot12CharactersRg(string rg)
        {
            var customer = CustomerBuilder.New().WithRg(rg).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }


        [Theory]
        [InlineData("aaaaaaaaaaaaaaaa")]
        [InlineData("aaaaaaaaaaaaaa")]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithNot14CharactersCpf(string cpf)
        {
            var customer = CustomerBuilder.New().WithCpf(cpf).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }


        [Fact]
        public void NotCreateWithLessThanMinimumRegisterDate()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MinValue).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void NotCreateWithMoreThanMaximumRegisterDate()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MaxValue).Build();

            customer.Validations.Errors.Should().NotBeEmpty();
        }

    }
}
