using MarsRover.Domain;

namespace MarsRover.Validator
{
    public interface ILocationValidator
    {
        bool Validate(Location location, IPlateu plateu);

        
    }
}
