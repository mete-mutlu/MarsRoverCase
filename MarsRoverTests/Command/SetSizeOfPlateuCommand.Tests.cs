using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace MarsRover.Tests.Command
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
        
        public void SetRecieverShouldNotThrowException([Frozen]Mock<PlateuBase> plateu,Size size)
        {
            plateu.Setup(x => x.Size).Returns(size);
            SetPlateuSizeCommand sut = new SetPlateuSizeCommand(new Size(3,3)) ;
            Action actual  = () => sut.SetReceiver(plateu.Object);
            actual.Should().NotThrow<Exception>();
        }

        [Theory]
        [AutoMock]
        public void ShouldSetPlateuSize([Frozen]Mock<PlateuBase> plateu, Size size)
        {
            SetPlateuSizeCommand sut = new SetPlateuSizeCommand(size);
            sut.SetReceiver(plateu.Object);
            sut.Execute();

            plateu.VerifySet(p=> p.Size = It.Is<Size>(p => p.Height == size.Height && p.Width == size.Width) ,Times.Once);
        }


       

        
    }
}
