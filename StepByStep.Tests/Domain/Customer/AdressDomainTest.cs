using FluentAssertions;
using StepByStep.Test.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StepByStep.Test.Domain
{
    public class AdressDomainTest
    {

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyCep(string cep)
        {
            var adress = AdressBuilder.New().WithCep(cep).Build();

            adress.Validations.Errors.Should().NotBeEmpty();
            adress.Validations.Errors.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyRoad(string road)
        {
            var adress = AdressBuilder.New().WithRoad(road).Build();

            adress.Validations.Errors.Should().NotBeEmpty();
            adress.Validations.Errors.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyNumber(string number)
        {
            var adress = AdressBuilder.New().WithNumber(number).Build();

            adress.Validations.Errors.Should().NotBeEmpty();
            adress.Validations.Errors.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyNeighborhood(string neighborhood)
        {
            var adress = AdressBuilder.New().WithNeighborhood(neighborhood).Build();

            adress.Validations.Errors.Should().NotBeEmpty();
            adress.Validations.Errors.Should().NotBeNull();
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyCity(string city)
        {
            var adress = AdressBuilder.New().WithCity(city).Build();

            adress.Validations.Errors.Should().NotBeEmpty();
            adress.Validations.Errors.Should().NotBeNull();
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotCreateWithEmptyState(string state)
        {
            var adress = AdressBuilder.New().WithState(state).Build();

            adress.Validations.Errors.Should().NotBeEmpty();
            adress.Validations.Errors.Should().NotBeNull();
        }
       

    }
}
