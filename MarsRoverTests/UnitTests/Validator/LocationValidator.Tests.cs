﻿using AutoFixture.Xunit2;
using FluentAssertions;
using MarsRover.Domain;
using MarsRover.Validator;
using Moq;
using Xunit;


namespace MarsRover.Tests.UnitTests.Validator
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
        public void GivenLocation_ValidateShouldReturnExpected(int xCoordinate, int yCoordinate,bool expected, [Frozen] Mock<IPlateu> plateu, LocationValidator sut)
        {
            plateu.SetupGet(p => p.Size).Returns(new Size(5, 5));

            var actual = sut.Validate(new Location(xCoordinate, yCoordinate),plateu.Object);

            actual.Should().Be(expected);
        }
    }

}
