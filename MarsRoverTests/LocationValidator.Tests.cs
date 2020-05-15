using AutoFixture.Xunit2;
using Moq;
using System.Collections;
using System.Collections.Generic;
using Xunit;


namespace MarsRover.Tests
{
    public class LocationValidatorTests
    {
        [Theory, AutoMock]
        public void GivenOutOfBoundaryLocation_ValidateShouldReturnFalse([Frozen]Mock<PlateuBase> plateu, Location location, LocationValidator sut)
        {
            plateu.SetupGet(p => p.Size).Returns(new Size(5, 5));

            location = new Location(5, 6);
            Assert.False(sut.Validate(location));

            location = new Location(6, 5);
            Assert.False(sut.Validate(location));

            location = new Location(5, 4);
            Assert.False(sut.Validate(location));

            location = new Location(4, 5);
            Assert.False(sut.Validate(location));

            location = new Location(-1, 0);
            Assert.False(sut.Validate(location));

            location = new Location(2, -1);
            Assert.False(sut.Validate(location));
        }


        [Theory, AutoMock]
        public void GivenInBoundaryLocation_ValidateShouldReturnTrue([Frozen]Mock<PlateuBase> plateu, Location location, LocationValidator sut)
        {
            plateu.SetupGet(p => p.Size).Returns(new Size(5, 5));

            location = new Location(4, 4);
            Assert.True(sut.Validate(location));

            location = new Location(3, 4);
            Assert.True(sut.Validate(location));

            location = new Location(0, 0);
            Assert.True(sut.Validate(location));
        }
    }

}
