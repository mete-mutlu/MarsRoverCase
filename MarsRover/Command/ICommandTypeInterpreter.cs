namespace MarsRover.Command
{
    public interface ICommandTypeInterpreter
    {
        CommandType GetCommandType(string command);
    }
}
