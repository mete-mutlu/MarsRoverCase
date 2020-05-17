using MarsRover.Domain;


namespace MarsRover.Command
{

    public class SetPlateuSizeCommand : ISetPlateuSizeCommand
    {
        public Size Size { get; set; }
        private IPlateu plateu  { get; set; }

        public CommandType CommandType { get; set; }

        public SetPlateuSizeCommand(Size size)
        {
            this.Size = size;
        }

        public void SetReceiver(IPlateu plateu)
        {
            this.plateu = plateu;
        }

        public void Execute()
        {
            plateu.Size = this.Size;
        }
    }
}
