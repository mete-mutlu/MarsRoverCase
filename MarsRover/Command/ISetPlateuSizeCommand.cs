using MarsRover.Domain;

namespace MarsRover.Command
{
    public interface ISetPlateuSizeCommand : ICommand
    {
        Size Size { get; }
        void SetReceiver(IPlateu plateu);
    }

}
