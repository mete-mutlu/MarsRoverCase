using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MarsRover
{
 
    public class CommandInvoker : ICommandInvoker
    {
        private  IEnumerable<ICommand> commands;
        private PlateuBase plateu;
        private readonly IRoverFactory roverFactory;
        private readonly IDictionary<CommandType, Action<ICommand>> recieverMethodDictionary;
        private IList<IRover> rovers;

        public CommandInvoker(IRoverFactory roverFactory) {
            this.roverFactory = roverFactory;
            recieverMethodDictionary = new Dictionary<CommandType, Action<ICommand>>
            {
                {CommandType.SetPlateauSize, SetReceiversOnSetPletauSizeCommand},
                {CommandType.Land, SetReceiversOnLandingCommand},
                {CommandType.Move, SetReceiversOnMovementCommand}
            };
        }


        public void SetPlateu(PlateuBase plateu)
        {
            this.plateu = plateu;
        }

        public void SetRovers(IList<IRover> rovers)
        {
            this.rovers = rovers;
        }

        public void SetCommands(IEnumerable<ICommand> commands)
        {
            this.commands = commands;
        }

        public void InvokeCommands()
        {
            foreach (var command in commands)
            {
                SetReceivers(command);
                command.Execute();
            }
        }

        private void SetReceivers(ICommand command)
        {
            recieverMethodDictionary[command.CommandType].Invoke(command);
        }

        private void SetReceiversOnSetPletauSizeCommand(ICommand command)
        {
            var setPlateuSizeCommand = (ISetPlateuSizeCommand)command;
            setPlateuSizeCommand.SetReceiver(plateu);
        }

        private void SetReceiversOnLandingCommand(ICommand command)
        {
            var landingCommand = (ILandingCommand)command;
            var rover = roverFactory.CreateRover();
            rovers.Add(rover);
            landingCommand.SetReceivers(rover, plateu);
        }

        private void SetReceiversOnMovementCommand(ICommand command)
        {
            var movementCommand = (IMovementCommand)command;
            var last = rovers[rovers.Count - 1];
            movementCommand.SetReceiver(last);
        }
    }
}
