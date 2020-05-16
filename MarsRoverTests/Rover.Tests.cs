using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {
        [Theory]
        [InlineDataWithAutoMoq(2, 5, Direction.South)]
        [InlineDataWithAutoMoq(4, 5, Direction.North)]
        public void GivenValidLocationAndDirectionForLandingProportiesShouldBeSetCorrectly(int expectedX, int expectedY, Direction expectedDirection, PlateuBase plateu,
          Mock<ILocationValidator> locationValidator, Rover sut)
        {
            var expectedLocation = new Location(expectedX, expectedY);
            locationValidator.Setup(x => x.Validate(expectedLocation)).Returns(true);
            sut.Land(locationValidator.Object, plateu, expectedLocation, expectedDirection);

            sut.Location.Should().BeEquivalentTo(expectedLocation);
            sut.Direction.Should().Be(expectedDirection);
        }

        [Fact]
        public void ValidatesLocationBeforeLanding()
        {
            throw new NotImplementedException();
        }


    }
}
