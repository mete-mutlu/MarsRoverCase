using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface ICommandMapper
    {
        IEnumerable<ICommand> Map(string commandText);
    }
}
