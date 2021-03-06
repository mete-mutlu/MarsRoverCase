using AutoFixture.Xunit2;
using FluentAssertions;
using MarsRover.Command;
using MarsRover.Domain;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Tests.UnitTests.Command
{
    public class MovementCommandTests
    {
        [Theory]
        [InlineData(new Movement[] { Movement.Forward,Movement.Left,Movement.Right})]
        public void ConstructorShouldSetMovements(IList<Movement> expected)
        {
            var sut = new MovementCommand(expected);

            var actual = sut.Movements;

            actual.Should().BeEquivalentTo(expected);

        }

        [Theory]
        [InlineDataWithAutoMoq(new Movement[] { Movement.Forward, Movement.Left, Movement.Right })]
        public void SetRecieverShouldAcceptMovements(IList<Movement> movements,[Frozen]Mock<IRover> rover)
        {
            var sut = new MovementCommand(movements);

            Action actual  = () => sut.SetReceiver(rover.Object);

            actual.Should().NotThrow<System.Exception>();

        }

        [Theory]
        [InlineDataWithAutoMoq(new Movement[] { Movement.Forward, Movement.Left, Movement.Right })]
        public void SetRecieverAndExecuteShouldMakeRoverMove(IList<Movement> expected, [Frozen]Mock<IRover> rover)
        {
            var sut = new MovementCommand(expected);

            sut.SetReceiver(rover.Object);
            sut.Execute();

            rover.Verify(p => p.Move(expected),Times.Once);

        }
    }
}
