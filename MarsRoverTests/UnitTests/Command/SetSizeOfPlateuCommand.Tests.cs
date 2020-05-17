using AutoFixture.Xunit2;
using FluentAssertions;
using MarsRover.Command;
using MarsRover.Domain;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace MarsRover.Tests.UnitTests.Command
{
    public class SetSizeOfPlateuCommandTests
    {
        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void ConstructorShouldSetSizeProperty(int expectedX, int expectedY)
        {
            var expected = new Size(expectedX, expectedY);
            SetPlateuSizeCommand sut = new SetPlateuSizeCommand(new Size(expectedX, expectedY));

            var actual = sut.Size;

            actual.Should().BeEquivalentTo(expected);

        }

        [Theory]
        [AutoMock]

        public void SetRecieversShouldHaveRecievers([Frozen]Mock<IPlateu> plateu, Size size)
        {
            plateu.Setup(x => x.Size).Returns(size);
            SetPlateuSizeCommand sut = new SetPlateuSizeCommand(new Size(3, 3));
            Action actual = () => sut.SetReceiver(plateu.Object);
            actual.Should().NotThrow<System.Exception>();
        }

        [Theory]
        [AutoMock]
        public void SetPletauShouldSetPlateuSize([Frozen]Mock<IPlateu> plateu, Size size)
        {
            SetPlateuSizeCommand sut = new SetPlateuSizeCommand(size);
            sut.SetReceiver(plateu.Object);
            sut.Execute();

            plateu.VerifySet(p => p.Size = It.Is<Size>(p => p.Height == size.Height && p.Width == size.Width), Times.Once);
        }





    }
}
