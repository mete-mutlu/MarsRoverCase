using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover
{
    [ExcludeFromCodeCoverage]
    public class CommandInvoker
    {
        private readonly List<ICommand> commands;
        private ICommand command;

        public CommandInvoker() { 
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => this.command = command;

        public void Invoke()
        {
            commands.Add(command);
            command.Execute();
        }
    }
}
