using MarsRover.Domain;
using System.Collections.Generic;

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
