using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using System.Collections;
using System.Collections.Generic;
using Xunit;


namespace MarsRover.Tests
{
    public class LocationValidatorTests
    {


        [Theory]
        [InlineDataWithAutoMoq(5, 6, false)]
        [InlineDataWithAutoMoq(6, 5, false)]
        [InlineDataWithAutoMoq(-1, 0, false)]
        [InlineDataWithAutoMoq(2, -1, false)]
        [InlineDataWithAutoMoq(5, 5, true)]
        [InlineDataWithAutoMoq(3, 4, true)]
        [InlineDataWithAutoMoq(0, 0, true)]
        public void GivenInBoundaryLocation_ValidateShouldReturnExpected(int xCoordinate, int yCoordinate,bool expected, [Frozen] Mock<PlateuBase> plateu, LocationValidator sut)
        {
            plateu.SetupGet(p => p.Size).Returns(new Size(5, 5));

            var actual = sut.Validate(new Location(xCoordinate, yCoordinate));

            actual.Should().Be(expected);
        }
    }

}
