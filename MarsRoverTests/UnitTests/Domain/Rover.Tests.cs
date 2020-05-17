using AutoFixture.Xunit2;
using FluentAssertions;
using MarsRover.Domain;
using MarsRover.Exception;
using MarsRover.Validator;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests.UnitTests.Domain
{
    public class RoverTests
    {
        [Theory]
        [InlineDataWithAutoMoq(2, 5, Direction.South)]
        [InlineDataWithAutoMoq(4, 5, Direction.North)]
        public void GivenValidLocationAndDirectionForLandingProportiesShouldBeSetCorrectly(int expectedX, int expectedY, Direction expectedDirection, IPlateu expectedPlateu,
          [Frozen]Mock<ILocationValidator> locationValidator, Rover sut)
        {

            var expectedLocation = new Location(expectedX, expectedY);
            locationValidator.Setup(x => x.Validate(expectedLocation, expectedPlateu)).Returns(true);
            sut.Land(expectedPlateu, expectedLocation, expectedDirection);

            sut.Location.Should().BeEquivalentTo(expectedLocation);
            sut.Direction.Should().Be(expectedDirection);
            sut.Plateu.Should().BeEquivalentTo(expectedPlateu);
        }

        [Theory]
        [AutoMock]
        public void WhenRoverIsLandingItValidatesTheLocationIsValidOrNot(Location location, IPlateu plateu, Direction direction,
           [Frozen]Mock<ILocationValidator> validator, Rover sut)
        {

            validator.Setup(p => p.Validate(location, plateu)).Returns(true);//any value

            sut.Land(plateu, location, direction);

            validator.Verify(x => x.Validate(location, plateu), Times.Once());
        }


        [Theory]
        [AutoMock]
        public void GivenInvalidLocation_LandShouldThrowException([Frozen]Mock<ILocationValidator> locationValidator, Mock<IPlateu> plateu
            , Location invalidLocation, Direction direction, Rover sut)
        {
            locationValidator.Setup(x => x.Validate(invalidLocation, plateu.Object)).Returns(false);


            Action actual = () => sut.Land(plateu.Object, invalidLocation, direction);

            actual.Should().Throw<OutOfBoundaryLandingException>();

        }


        [Theory]
        [InlineDataWithAutoMoq(2, 2, Direction.North, new Movement[] { Movement.Forward }, 2, 3, Direction.North)]
        [InlineDataWithAutoMoq(1, 3, Direction.South, new Movement[] { Movement.Left, Movement.Forward }, 2, 3, Direction.East)]
        [InlineDataWithAutoMoq(4, 4, Direction.East, new Movement[] { Movement.Right, Movement.Forward, Movement.Right }, 4, 3, Direction.West)]
        [InlineDataWithAutoMoq(2, 4, Direction.West, new Movement[] { Movement.Forward, Movement.Left, Movement.Forward, Movement.Forward }, 1, 2, Direction.South)]
        public void GivenValidDataRoverShouldLandsAndMovesToExpectedLocationAndDirection(int xCoordinateAtStart, int yCoordinateAtStart, Direction directionAtStart, IList<Movement> movements,
            int expectedXCoordinate, int expectedYCoordinate, Direction expectedDirection, [Frozen]Mock<ILocationValidator> locationValidator, Mock<IPlateu> plateu, Size size, Rover sut)
        {

            var locationAtStart = new Location(xCoordinateAtStart, yCoordinateAtStart);
            locationValidator.Setup(x => x.Validate(It.IsAny<Location>(), It.IsAny<IPlateu>())).Returns(true);
            plateu.Setup(x => x.Size).Returns(size);


            sut.Land(plateu.Object, locationAtStart, directionAtStart);
            sut.Move(movements);
            var expectedLocation = new Location(expectedXCoordinate, expectedYCoordinate);

            var actualLocation = sut.Location;
            var actualDirection = sut.Direction;

            actualLocation.Should().BeEquivalentTo(expectedLocation);
            actualDirection.Should().Be(expectedDirection);

        }

        [Theory]
        [InlineDataWithAutoMoq(new Movement[] { Movement.Forward })]

        public void WhenRoverTriesToMoveOutOfPlateuThrowsException(IList<Movement> movements,
            [Frozen]Mock<ILocationValidator> locationValidator, IPlateu plateu
            , Location validLocation, Direction direction, Rover sut)
        {
            locationValidator.Setup(x => x.Validate(It.IsAny<Location>(), It.IsAny<IPlateu>())).Returns(true);

            sut.Land(plateu, validLocation, direction);

            locationValidator.Setup(x => x.Validate(It.IsAny<Location>(), It.IsAny<IPlateu>())).Returns(false);

            Action actual = () => sut.Move(movements);

            actual.Should().Throw<OutOfBoundaryMovementException>();
            

        }


        [Theory(DisplayName = "")]
        [InlineDataWithAutoMoqAttribute()]
        public void WhenRoverLandsSuccesfullyIsLandedPropertyShouldBeTrue([Frozen]Mock<ILocationValidator> locationValidator
            ,Location anyLocation,IPlateu anyPlateu,Direction   anyDirection, Rover sut)
        {
            locationValidator.Setup(x => x.Validate(It.IsAny<Location>(), It.IsAny<IPlateu>())).Returns(true);
            sut.Land(anyPlateu, anyLocation, anyDirection);
            var actual = sut.IsLanded();
            actual.Should().BeTrue();

        }


        [Theory(DisplayName = "")]
        [AutoMock]
        public void WhenRoverCreatedIsLandedShouldBeFalse( Rover sut)
        {
            var actual = sut.IsLanded();
            actual.Should().BeFalse();

        }
    }
}
