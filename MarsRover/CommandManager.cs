using MarsRover.Command;
using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover
{

    public class CommandManager : ICommandManager
    {
        private readonly IPlateu plateu;
        private readonly ICommandInvoker commandInvoker;
        private readonly ICommandMapper commandMapper;
        private readonly IList<IRover> rovers;
        private readonly IOutputGenerator outputGenerator;

        public CommandManager(IPlateu plateu, ICommandMapper commandMapper, ICommandInvoker commandInvoker, IOutputGenerator outputGenerator) 
        {
            rovers = new List<IRover>();
            this.plateu = plateu;
            this.commandMapper = commandMapper;
            this.commandInvoker = commandInvoker;
            this.outputGenerator = outputGenerator;
            this.commandInvoker.SetPlateu(this.plateu);
            this.commandInvoker.SetRovers(rovers);
        }

        public void Execute(string input)
        {
            var commandList = commandMapper.Map(input);
            commandInvoker.SetCommands(commandList);
            commandInvoker.InvokeCommands();
        }

        public string GetOutput()
        {
            return outputGenerator.GetOutput(rovers);
        }
    }
}
