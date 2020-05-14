using PersonalNumberValidator.Common;
using PersonalNumberValidator.Extensions;

namespace PersonalNumberValidator.Validators
{
    public class BasicValidator : IValidator
    {
        public Result Validate(string number)
        {
            if (number.Length != 10)
            {
                return Result.Failure("Personal number should be 10 digits.");
            }

            if (!number.IsNumber())
            {
                return Result.Failure("Personal number should contains only digits.");
            }

            return Result.Success();
        }

        public int Order { get; } = 1;
    }
}
