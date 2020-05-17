using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface ICommandInvoker
    {
        void SetPlateu(IPlateu plateu);
        void SetRovers(IList<IRover> rovers);
        void SetCommands(IEnumerable<ICommand> commands);
        void InvokeCommands();
    }
}
