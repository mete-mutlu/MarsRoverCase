using System.Diagnostics.CodeAnalysis;

namespace MarsRover.Domain
{
    [ExcludeFromCodeCoverage]
    public class Size 
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public Size( int width , int height)
        {
            Height = height;
            Width = width;
        }
    }
}
