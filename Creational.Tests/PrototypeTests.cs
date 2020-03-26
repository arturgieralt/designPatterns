using System;
using System.Collections.Generic;
using Creational.Prototype;
using FluentAssertions;
using Xunit;

namespace Creational.Tests
{
    public class PrototypeTests
    {
        [Fact]
        public void WhenCloningGetTotalPriceShouldReturnProperValue()
        {
            var configurationList = new CarConfigurationManager();
            var bmw = new CarModel()
            {
                Name = "BMW",
                BasePrice = 100000
            };

            var engineUpgrade = new CarPart()
            {
                Name = "V12",
                Price = 50000
            };
            var breaksUpgrade = new CarPart() 
            {
                Name = "ExtraBreaks",
                Price = 20000
            };

            var configuration = new CarConfiguration("BMWV12", bmw, new List<CarPart>() {
                engineUpgrade, breaksUpgrade
            });

            configurationList["BMWV12"] = configuration;

            var clonedConfiguration = configurationList["BMWV12"].Clone() as CarConfiguration;

            clonedConfiguration.GetTotalPrice().Should().Be(configuration.GetTotalPrice());
        }
    }
}
