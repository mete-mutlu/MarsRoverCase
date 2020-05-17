using AutoFixture.Xunit2;
using FluentAssertions;
using MarsRover.Command;
using MarsRover.Domain;
using MarsRover.Factory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.Tests.UnitTests.Command
{
    public class CommandInvokerTests
    {
        [Theory]
        [AutoMock]
        public void ConstructorShouldAcceptFactoryParameter(Mock<IRoverFactory> roverFactory, Rover rover)
        {
            roverFactory.Setup(p => p.CreateRover()).Returns(rover);

            Action actual = () => new CommandInvoker(roverFactory.Object);

            actual.Should().NotThrow<System.Exception>();

        }

        [Theory]
        [AutoMock]
        public void SetRoversShouldAcceptRovers(IList<IRover> rovers, CommandInvoker sut)
        {

            Action actual = () => sut.SetRovers(rovers);

            actual.Should().NotThrow<System.Exception>();

        }

        [Theory]
        [AutoMock]
        public void SetCommandsShouldAcceptCommands(IEnumerable<ICommand> commands, CommandInvoker sut)
        {

            Action actual = () => sut.SetCommands(commands);

            actual.Should().NotThrow<System.Exception>();

        }


        [Theory]
        [AutoMock]
        public void InvokeAllShouldExecuteEveryCommandOnce(IEnumerable<Mock<ISetPlateuSizeCommand>> commands, CommandInvoker sut)
        {
            foreach (var command in commands)
            {
                command.Setup(p => p.CommandType).Returns(CommandType.SetPlateauSize);
                command.Setup(p => p.Size).Returns(new Size(1, 1));
            }
            sut.SetCommands(commands.Select(p => p.Object));
            sut.InvokeCommands();

            foreach (var command in commands)
                command.Verify(p => p.Execute(), Times.Once);

        }

        [Theory]
        [AutoMock]
        public void WhenSetPlateuCommandExecutingPlateuShouldBeSet(Mock<ISetPlateuSizeCommand> command,
            IPlateu plateu, CommandInvoker sut)
        {

            command.Setup(p => p.CommandType).Returns(CommandType.SetPlateauSize);

            sut.SetPlateu(plateu);
            sut.SetCommands(new List<ICommand> { command.Object });
            sut.InvokeCommands();

            command.Verify(p => p.SetReceiver(plateu), Times.Once);

        }

        [Theory]
        [AutoMock]
        public void WhenLandingCommandExecutingParametersShouldBeSetAndFireSetRecievers(
        Mock<ILandingCommand> command, [Frozen]Mock<IRover> expectedRover,
        Mock<IPlateu> expectedPlateu, [Frozen]Mock<IRoverFactory> roverFactory, CommandInvoker sut)
        {
            expectedPlateu.Setup(p => p.Size).Returns(new Size(3, 3));
            command.Setup(p => p.CommandType).Returns(CommandType.Land);
            roverFactory.Setup(p => p.CreateRover()).Returns(expectedRover.Object);

            sut.SetCommands(new List<ICommand> { command.Object });
            sut.SetPlateu(expectedPlateu.Object);
            sut.SetRovers(new List<IRover>());
            sut.InvokeCommands();

            command.Verify(p => p.SetReceivers(expectedRover.Object, expectedPlateu.Object), Times.Once);

        }


        [Theory]
        [AutoMock]
        public void WhenMoveCommandExecutingParametersShouldBeSetToExpectedRover(Mock<IMovementCommand> command, IList<IRover> rovers,
        [Frozen]Mock<IRover> expectedRover, CommandInvoker sut)
        {

            command.Setup(p => p.CommandType).Returns(CommandType.Move);
            rovers.Add(expectedRover.Object);
            sut.SetCommands(new List<ICommand> { command.Object });
            sut.SetRovers(rovers);
            sut.InvokeCommands();

            command.Verify(x => x.SetReceiver(expectedRover.Object), Times.Once());

        }




    }
}
