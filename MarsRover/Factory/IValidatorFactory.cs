using MarsRover.Validator;

namespace MarsRover.Factory
{
    public interface IValidatorFactory
    {
        ILocationValidator CreateLocationValidator();
    }
}
