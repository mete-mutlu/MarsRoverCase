using MarsRover.Validator;

namespace MarsRover.Factory
{
    public class ValidatorFactory : IValidatorFactory
    {
        public ILocationValidator CreateLocationValidator()
        {
            return new LocationValidator();
        }
    }
}
