using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface ICommandTypeInterpreter
    {
        CommandType GetCommandType(string command);
    }
}
