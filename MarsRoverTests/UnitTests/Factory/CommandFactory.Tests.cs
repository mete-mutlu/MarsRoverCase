using FluentAssertions;
using MarsRover.Command;
using MarsRover.Domain;
using MarsRover.Factory;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests.UnitTests.Factory
{
    public class CommandFactoryTests
    {


        [Theory]
        [InlineDataWithAutoMoq]
        public void CreateLandingCommandShouldReturnExpectedType(Location location, Direction direction, CommandFactory sut)
        {

            var actual = sut.CreateLandingCommand(location, direction);
            var actualCommandType = actual.CommandType;

            actualCommandType.Should().Be(CommandType.Land);
            actual.Should().BeOfType<LandingCommand>();
            actual.Should().BeAssignableTo<ILandingCommand>();

        }

        [Theory]
        [InlineDataWithAutoMoq]
        public void CreateSetPlateuSizeCommandShouldReturnExpectedType(Size size, CommandFactory sut)
        {
            var actual = sut.CreateSetPlateuSizeCommand(size);
            var actualCommandType = actual.CommandType;

            actualCommandType.Should().Be(CommandType.SetPlateauSize);
            actual.Should().BeOfType<SetPlateuSizeCommand>();
            actual.Should().BeAssignableTo<ISetPlateuSizeCommand>();
        }
        [Theory]
        [InlineDataWithAutoMoq]
        public void CreateMovementCommandShouldReturnExpectedType(IList<Movement> movements, CommandFactory sut)
        {
            var actual = sut.CreateMovementCommand(movements);
            var actualCommandType = actual.CommandType;
            actualCommandType.Should().Be(CommandType.Move);
            actual.Should().BeOfType<MovementCommand>();
            actual.Should().BeAssignableTo<IMovementCommand>();
        }
    }
}
