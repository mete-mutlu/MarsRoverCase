namespace MarsRover.Command
{

    public interface ICommand
    {
        CommandType CommandType { get; }
        void Execute();
    }
}
