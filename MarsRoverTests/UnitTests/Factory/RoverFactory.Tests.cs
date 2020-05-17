using FluentAssertions;
using MarsRover.Domain;
using MarsRover.Factory;
using Xunit;

namespace MarsRover.Tests.UnitTests.Factory
{
    public class RoverFactoryTests
    {
        [Theory]
        [InlineDataWithAutoMoq]
        public void CreateRoverShouldReturnExpectedType(RoverFactory sut)
        {
            var actual = sut.CreateRover();

            actual.Should().BeOfType<Rover>();
            actual.Should().BeAssignableTo<IRover>();
        }
    }
}
