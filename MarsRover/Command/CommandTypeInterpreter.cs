using MarsRover.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Command
{
    public class CommandTypeInterpreter : ICommandTypeInterpreter
    {
        private IDictionary<string, CommandType> commandTypeDictionary;

        public CommandTypeInterpreter()
        {
            commandTypeDictionary = new Dictionary<string, CommandType>
            {
                { @"^\d+ \d+$", CommandType.SetPlateauSize },
                { @"^\d+ \d+ [NSEW]$", CommandType.Land },
                { @"^[LRM]+$", CommandType.Move }
            };
        }

        public CommandType GetCommandType(string command)
        {
            var commandType = commandTypeDictionary.FirstOrDefault(x => new Regex(x.Key).IsMatch(command));

            return commandType.Key != null ? commandType.Value : throw new InvalidCommandException();

        }

    }
}
