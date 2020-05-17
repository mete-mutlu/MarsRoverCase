using AutoFixture.Xunit2;
using FluentAssertions;
using FluentAssertions.Equivalency;
using MarsRover.Command;
using MarsRover.Domain;
using MarsRover.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MarsRover.Tests.UnitTests.Command
{
    public class CommandMapperTests
    {
        [Theory]
        [InlineDataWithAutoMoq("5 7", 5, 7)]
        [InlineDataWithAutoMoq("2 1", 2, 1)]
        public void GivenValidSetPlateuSizeCommand_MapShouldReturnCorrectSizeAndCorrectCommandType
            (string commandText, int expectedWidth, int expectedHeight, [Frozen]Mock<ICommandTypeInterpreter> interpreter, [Frozen]Mock<ICommandFactory> factory, [Frozen]Mock<ISetPlateuSizeCommand> expectedCommand, CommandMapper sut)
        {
            expectedCommand.Setup(x => x.Size).Returns(new Size(expectedWidth, expectedHeight));
            interpreter.Setup(x => x.GetCommandType(It.IsAny<string>())).Returns(CommandType.SetPlateauSize);
            factory.Setup(x => x.CreateSetPlateuSizeCommand(It.Is<Size>(p => p.Height == expectedHeight && p.Width == expectedWidth)))
                   .Returns(expectedCommand.Object);

            ISetPlateuSizeCommand actual = (ISetPlateuSizeCommand)sut.Map(commandText).First();

            actual.Should().BeEquivalentTo(expectedCommand.Object);

        }


        [Theory]
        [InlineDataWithAutoMoq("5 1 N", 5, 1, Direction.North)]
        [InlineDataWithAutoMoq("3 6 S", 3, 6, Direction.South)]
        [InlineDataWithAutoMoq("3 6 W", 3, 6, Direction.West)]
        public void GivenValidLandingCommand_MapShouldReturnCorrectCommand
       (string commandText, int expectedXCoordinate, int expectedYCoordinate, Direction expectedDirection, [Frozen]Mock<ICommandTypeInterpreter> interpreter, [Frozen]Mock<ICommandFactory> factory, [Frozen]Mock<ILandingCommand> expectedCommand, CommandMapper sut)
        {
            expectedCommand.Setup(x => x.Location).Returns(new Location(expectedXCoordinate, expectedYCoordinate));
            expectedCommand.Setup(x => x.Direction).Returns(expectedDirection);
            interpreter.Setup(x => x.GetCommandType(It.IsAny<string>())).Returns(CommandType.Land);
            factory.Setup(x => x.CreateLandingCommand(It.Is<Location>(p => p.X == expectedXCoordinate && p.Y == expectedYCoordinate), It.Is<Direction>(p => p == expectedDirection)))
                   .Returns(expectedCommand.Object);

            var actual = (ILandingCommand)sut.Map(commandText).First();

            actual.Should().BeEquivalentTo(expectedCommand.Object);

        }

        [Theory]

        [InlineDataWithAutoMoq("M", new Movement[] { Movement.Forward })]
        [InlineDataWithAutoMoq("RM", new Movement[] { Movement.Right, Movement.Forward })]
        [InlineDataWithAutoMoq("RLM", new Movement[] { Movement.Right, Movement.Left, Movement.Forward })]
        [InlineDataWithAutoMoq("MRML", new Movement[] { Movement.Forward, Movement.Right, Movement.Forward, Movement.Left })]

        public void GivenValidMovementCommand_MapShouldReturnExpectedCommand
(string commandText, IList<Movement> expectedMovements, [Frozen]Mock<ICommandTypeInterpreter> interpreter, [Frozen]Mock<ICommandFactory> factory, [Frozen]Mock<IMovementCommand> expectedCommand, CommandMapper sut)
        {
            expectedCommand.Setup(x => x.Movements).Returns(expectedMovements);
            expectedCommand.Setup(x => x.CommandType).Returns(CommandType.Move);
            interpreter.Setup(x => x.GetCommandType(It.IsAny<string>())).Returns(CommandType.Move);
            factory.Setup(x => x.CreateMovementCommand(It.Is<IList<Movement>>(p => p.SequenceEqual(expectedMovements)))).Returns(expectedCommand.Object);

            var actual = (IMovementCommand)sut.Map(commandText).First();

            actual.Should().BeEquivalentTo(expectedCommand.Object);

        }


    }
}
