using AutoFixture.Xunit2;
using FluentAssertions;
using MarsRover.Command;
using MarsRover.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Tests.UnitTests
{
    public class CommandManagerTests
    {
        [Theory]
        [InlineDataWithAutoMoq]
        public void OnInitializeShouldSetPlateu([Frozen]Mock<ICommandInvoker> invoker, CommandManager sut)
        {
            invoker.Verify(p => p.SetPlateu(It.IsAny<IPlateu>()), Times.Once);
        }

        [Theory]
        [InlineDataWithAutoMoq]
        public void OnInitializeShouldSetRovers([Frozen]Mock<ICommandInvoker> invoker, CommandManager sut)
        {
            invoker.Verify(p => p.SetRovers(It.IsAny<IList<IRover>>()), Times.Once);
        }

        [Theory]
        [InlineDataWithAutoMoq]
        public void OnExecuteShouldMapAndInvokeAllCommands([Frozen]Mock<IEnumerable<ICommand>> expectedCommands,
            [Frozen]Mock<ICommandMapper> mapper, [Frozen]Mock<ICommandInvoker> invoker, string anyCommandTextInput,
           CommandManager sut)
        {
            mapper.Setup(x => x.Map(null)).Returns(expectedCommands.Object);

            sut.Execute(anyCommandTextInput);

            invoker.Verify(p => p.SetCommands(expectedCommands.Object), Times.Once);
            invoker.Verify(p => p.InvokeCommands(), Times.Once);
        }


        [Theory]
        [AutoMock]
        public void OnGetOutputShouldGetExpectedOutput([Frozen]Mock<IOutputGenerator> outputGenerator,
            string anyExpectedOutput, CommandManager sut)
        {
            outputGenerator.Setup(p => p.GetOutput(It.IsAny<List<IRover>>())).Returns(anyExpectedOutput);
            var actual = sut.GetOutput();
            actual.Should().Be(anyExpectedOutput);
        }

       

    }
}
