using MarsRover.Domain;
using MarsRover.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Command
{
    public class CommandMapper : ICommandMapper
    {
        private readonly ICommandTypeInterpreter commandTypeInterpreter;
        private readonly ICommandFactory commandFactory;
        private readonly IDictionary<CommandType, Func<string, ICommand>> commandConvertDictionary;
        private readonly IDictionary<char, Direction> directionDictionary;
        private readonly IDictionary<char, Movement> movementDictionary;

        public CommandMapper(ICommandTypeInterpreter commandTypeInterpreter, ICommandFactory commandFactory)
        {
            this.commandTypeInterpreter = commandTypeInterpreter;
            this.commandFactory = commandFactory;

            commandConvertDictionary = new Dictionary<CommandType, Func<string, ICommand>>
            {
                 {CommandType.SetPlateauSize, ConvertPletauSizeCommand},
                 {CommandType.Land, ConvertLandingCommand},
                 {CommandType.Move, ConvertMovementCommand}
            };

            directionDictionary = new Dictionary<char, Direction>
            {
                 {'N', Direction.North},
                 {'S', Direction.South},
                 {'E', Direction.East},
                 {'W', Direction.West}
            };

            movementDictionary = new Dictionary<char, Movement>
            {
                 {'L', Movement.Left},
                 {'R', Movement.Right},
                 {'M', Movement.Forward}
            };
        }
        public IEnumerable<ICommand> Map(string commandText)
        {
            var commands = commandText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            return commands.Select(command => commandConvertDictionary[commandTypeInterpreter.GetCommandType(command)]
                    .Invoke(command)).AsEnumerable();
        }

        private ICommand ConvertPletauSizeCommand(string commandLine)
        {
            var coordinates = commandLine.Split(' ');
            var coordinateX = System.Convert.ToInt32(coordinates[0]);
            var coordinateY = System.Convert.ToInt32(coordinates[1]);

            var size = new Size(coordinateX, coordinateY);

            return commandFactory.CreateSetPlateuSizeCommand(size);
        }

        private ICommand ConvertLandingCommand(string commandLine)
        {
            var information = commandLine.Split(' ');
            int coordinateX = System.Convert.ToInt32(information[0]);
            int coordinateY = System.Convert.ToInt32(information[1]);
            var directionDictionaryKey = System.Convert.ToChar(information[2]);

            var location = new Location(coordinateX, coordinateY);
            Direction direction = directionDictionary[directionDictionaryKey];

            return commandFactory.CreateLandingCommand(location, direction);
        }

        private ICommand ConvertMovementCommand(string commandLine)
        {
            var charArray = commandLine.ToCharArray();
            var movements = charArray.Select(movement => movementDictionary[movement]).ToList();

            return commandFactory.CreateMovementCommand(movements);
        }
    }
}
