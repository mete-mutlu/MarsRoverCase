using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface ICommandTypeInterpreter
    {
        CommandType GetCommandType(string command);
    }
}
