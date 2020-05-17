using MarsRover.Domain;

namespace MarsRover.Command
{
    public interface ILandingCommand : ICommand
    {
        Direction Direction { get; set; }
        Location Location { get; set; }
        void SetReceivers(IRover rover, IPlateu plateu);
    }
}
