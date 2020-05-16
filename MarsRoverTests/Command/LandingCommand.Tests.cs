﻿using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Tests.Command
{
    public class LandingCommandTests
    {
        [Theory]
        [AutoMock]
        public void ConstructorShouldSetProperties(Mock<LocationValidator> validator, Location location, Direction direction)
        {

            var sut = new LandingCommand(validator.Object,location, direction);

            var actualLocation = sut.Location;
            var actualDirection = sut.Direction;

            actualLocation.Should().Be(location);
            actualDirection.Should().Be(direction);

        }

        [Theory]
        [AutoMock]

        public void SetRecieverShouldHaveRecievers(Mock<LocationValidator> validator, Location location, Direction direction,Mock<IRover> rover,Mock<PlateuBase> plateu)
        {
            var sut = new LandingCommand(validator.Object, location, direction);

            Action actual = () => sut.SetReceivers(rover.Object, plateu.Object);

            actual.Should().NotThrow<Exception>();
        }

        [Theory]
        [AutoMock]

        public void SetRecieversAndExecuteShouldFireRoverLand(Mock<LocationValidator> validator, Location location, Direction direction,[Frozen] Mock<IRover> rover, [Frozen] Mock<PlateuBase> plateu)
        {

            var sut = new LandingCommand(validator.Object,location, direction);

            sut.SetReceivers(rover.Object, plateu.Object);

            sut.Execute();

            rover.Verify(p => p.Land(validator.Object,plateu.Object, location, direction), Times.Once);
        }
    }
}
