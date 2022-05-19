using FluentAssertions;
using StepByStep.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StepByStep.Tests.Domain
{
    public class AddressDomainTest
    {

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyCep(string cep)
        {
            var Address = AddressBuilder.New().WithCep(cep).Build();

            Address.ValidationResult.Errors.Should().NotBeEmpty();
            Address.ValidationResult.Errors.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyRoad(string road)
        {
            var Address = AddressBuilder.New().WithRoad(road).Build();

            Address.ValidationResult.Errors.Should().NotBeEmpty();
            Address.ValidationResult.Errors.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyNumber(string number)
        {
            var Address = AddressBuilder.New().WithNumber(number).Build();

            Address.ValidationResult.Errors.Should().NotBeEmpty();
            Address.ValidationResult.Errors.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyNeighborhood(string neighborhood)
        {
            var Address = AddressBuilder.New().WithNeighborhood(neighborhood).Build();

            Address.ValidationResult.Errors.Should().NotBeEmpty();
            Address.ValidationResult.Errors.Should().NotBeNull();
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyCity(string city)
        {
            var Address = AddressBuilder.New().WithCity(city).Build();

            Address.ValidationResult.Errors.Should().NotBeEmpty();
            Address.ValidationResult.Errors.Should().NotBeNull();
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyState(string state)
        {
            var Address = AddressBuilder.New().WithState(state).Build();

            Address.ValidationResult.Errors.Should().NotBeEmpty();
            Address.ValidationResult.Errors.Should().NotBeNull();
        }
       

    }
}
