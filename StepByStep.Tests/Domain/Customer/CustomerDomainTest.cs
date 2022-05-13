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
        public void NotCreateWithEmptyName(string name)
        {
            var customer = CustomerBuilder.New().WithName(name).Build();

            customer.ValidationResult.Errors.Should().NotBeEmpty();
            //customer.Validations.Errors.Select(s => s.ErrorMessage).Should().Contain("Nome completo não pode ser em branco");
        }

        [Fact]
        public void NotCreateWithLessThanMinimumBirthday()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MinValue).Build();

            customer.ValidationResult.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void NotCreateWithMoreThanMaximumBirthday()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MaxValue).Build();

            customer.ValidationResult.Errors.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("aaaaaaaaaaaaaaaa")]
        [InlineData("aaaaaaaaaaaaaa")]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithNot12CharactersRg(string rg)
        {
            var customer = CustomerBuilder.New().WithRg(rg).Build();

            customer.ValidationResult.Errors.Should().NotBeEmpty();
        }


        [Theory]
        [InlineData("aaaaaaaaaaaaaaa")]
        [InlineData("aaaaaaaaaaaaa")]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithNot14CharactersCpf(string cpf)
        {
            var customer = CustomerBuilder.New().WithCpf(cpf).Build();

            customer.ValidationResult.Errors.Should().NotBeEmpty();
        }


        [Fact]
        public void NotCreateWithLessThanMinimumRegisterDate()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MinValue).Build();

            customer.ValidationResult.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void NotCreateWithMoreThanMaximumRegisterDate()
        {
            var customer = CustomerBuilder.New().WithBirthday(DateTime.MaxValue).Build();

            customer.ValidationResult.Errors.Should().NotBeEmpty();
        }
    }
}
