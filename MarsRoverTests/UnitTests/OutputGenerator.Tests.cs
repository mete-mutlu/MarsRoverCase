using AutoFixture.Xunit2;
using FluentAssertions;
using MarsRover.Domain;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.Tests.UnitTests
{
    public class OutputGeneratorTests
    {
        [Theory]
        [InlineDataWithAutoMoq]
        public void GeneratesOutputForAllRovers([Frozen]Mock<IEnumerable<IRover>> rovers,
            [Frozen]Mock<IRover> rover, OutputGenerator sut)
        {
            sut.GetOutput(rovers.Object);
            rover.VerifyGet(p => p.Location, Times.Exactly(rovers.Object.Count()));
            rover.VerifyGet(p => p.Direction, Times.Exactly(rovers.Object.Count()));
        }

        [Theory]
        [InlineDataWithAutoMoq(3, 4, Direction.East, true, "3 4 E")]
        [InlineDataWithAutoMoq(5, 2, Direction.West, true, "5 2 W")]
        [InlineDataWithAutoMoq(1, 3, Direction.South, true, "1 3 S")]
        [InlineDataWithAutoMoq(1, 3, Direction.South, false, "A Rover Could Not Landed!")]
        public void GeneratesOutputInExpectedFormat(int xCoordinate, int yCoordinate, Direction direction,bool isLanded, string expectedOutput,
        [Frozen]Mock<IRover> rover, OutputGenerator sut)
        {

            rover.Setup(p => p.Location).Returns(new Location(xCoordinate, yCoordinate));
            rover.Setup(p => p.Direction).Returns(direction);
            rover.Setup(p => p.IsLanded()).Returns(isLanded);

            var actual = sut.GetOutput(new List<IRover>() { rover.Object }.AsEnumerable());

            actual.Should().Be(expectedOutput);


        }
        struct TestData
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Direction Direction { get; set; }
        }

    }
}
