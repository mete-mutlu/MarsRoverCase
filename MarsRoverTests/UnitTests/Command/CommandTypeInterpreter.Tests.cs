using FluentAssertions;
using MarsRover.Command;
using MarsRover.Exception;
using System;
using Xunit;

namespace MarsRover.Tests.UnitTests.Command
{
    public class CommandTypeInterpreterTests
    {
        [Theory]
        [InlineDataWithAutoMoq("5 5", CommandType.SetPlateauSize)]
        [InlineDataWithAutoMoq("1 2 N", CommandType.Land)]
        [InlineDataWithAutoMoq("LMLMLMLMM", CommandType.Move)]
        [InlineDataWithAutoMoq("3 3 E", CommandType.Land)]
        [InlineDataWithAutoMoq("MMRMMRMRRM", CommandType.Move)]
        public void GivenValidCommandLine_GetCommandTypeShouldReturnACommandType(string given, CommandType excepted, CommandTypeInterpreter sut)
        {
            var actual = sut.GetCommandType(given);
            actual.Should().Be(excepted);
        }

        [Theory]
        [InlineDataWithAutoMoq("123123")]
        [InlineDataWithAutoMoq("1 2 3")]
        [InlineDataWithAutoMoq("LM LM")]
        [InlineDataWithAutoMoq("MLMLTR")]
        [InlineDataWithAutoMoq("MMRMMRMRRMT")]
        public void GivenInvalidCommandLine_GetCommandTypeShouldNotReturnACommandType(string given, CommandTypeInterpreter sut)
        {
            Action actual = () => sut.GetCommandType(given);
            actual.Should().Throw<InvalidCommandException>();
        }
    }
}
