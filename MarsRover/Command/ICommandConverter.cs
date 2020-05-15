using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface ICommandMapper
    {
        IEnumerable<ICommand> Map(string commandText);
    }
}
