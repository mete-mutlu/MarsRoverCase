using System.Collections.Generic;

namespace MarsRover.Command
{
    public interface ICommandMapper
    {
        IEnumerable<ICommand> Map(string commandText);
    }
}
