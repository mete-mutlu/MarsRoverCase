using FluentAssertions;
using MarsRover.Factory;
using MarsRover.Validator;
using Xunit;

namespace MarsRover.Tests.UnitTests.Factory
{
    public class ValidatorFactoryTests
    {

        [Theory]
        [InlineDataWithAutoMoq]
        public void CreatesLandingCommandShouldReturnExpectedType(ValidatorFactory sut)
        {
            var actual = sut.CreateLocationValidator();

            actual.Should().BeOfType<LocationValidator>();
            actual.Should().BeAssignableTo<ILocationValidator>();
        }
    }
}
