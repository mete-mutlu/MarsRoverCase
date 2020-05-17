using Autofac;
using FluentAssertions;
using MarsRover.Command;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;


namespace MarsRover.Tests
{
    public class AcceptenceTests : IClassFixture<AcceptenceTestFixture>
    {

        private string caseInput;
        private string expectedCaseOutput;
        private readonly ICommandManager commandManager;

        public AcceptenceTests(AcceptenceTestFixture fixture)
        {
            this.commandManager = fixture.Container.Resolve<ICommandManager>();
            caseInput = GenerateInputString();
            expectedCaseOutput = GenerateExpectedOutputString();
        }

        [Theory]
        [InlineData("10 10\r\n4 7 W\r\n3 4 S\r\n5 6 E", "4 7 W\r\n3 4 S\r\n5 6 E")]
        public void GivenSetPlatueAndLandCommands_ShouldReturnSameOutput(string commandInput,string expectedOutput)
        {

            commandManager.Execute(commandInput);
            string actual = commandManager.GetOutput();
            actual.Should().BeEquivalentTo(expectedOutput);
        }


        [Fact]
        public void GivenHepsiburadaCaseProblemInputStringShouldReturnExpectedOutput()
        {
            commandManager.Execute(caseInput);
            string actual = commandManager.GetOutput();
            actual.Should().Be(expectedCaseOutput);
        }

       


        private static string GenerateInputString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }

        private static string GenerateExpectedOutputString()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("1 3 N");
            commandStringBuilder.Append("5 1 E");
            return commandStringBuilder.ToString();
        }


    }

}
