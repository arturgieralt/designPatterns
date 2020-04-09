using Behavioral.Strategy;
using FluentAssertions;
using Xunit;

namespace Behavioral.Tests
{
    public class StrategyTests
    {
        [Fact]
        public void WhenCalculatingTax_AndOrderIsForPoland_ShouldReturnValue()
        {
            var polandTax = new PolishTax();
            var order = new Order(polandTax)
            {
                Name = "TV",
                Price = 1000
            };

            order.TotalPrice.Should().Be(1200);
        }

        [Fact]
        public void WhenCalculatingTax_AndOrderIsForUS_ShouldReturnValue()
        {
            var usTax = new USATax();
            var order = new Order(usTax)
            {
                Name = "TV",
                Price = 1000
            };

            order.TotalPrice.Should().Be(1050);
        }
    }
}