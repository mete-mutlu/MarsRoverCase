namespace MarsRover
{
    public interface ICommandManager
    {
        void Execute(string input);
        string GetOutput();
    }
}
