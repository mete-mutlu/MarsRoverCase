using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface ICommandInvoker
    {
        void SetPlateu(PlateuBase plateu);
        void SetRovers(IList<IRover> rovers);
        void SetCommands(IEnumerable<ICommand> commands);
        void InvokeCommands();
    }
}
