using PersonalNumberValidator.Common;

namespace PersonalNumberValidator.Validators
{
    internal interface IValidator
    {
        Result Validate(string number);

        int Order { get; }
    }
}
