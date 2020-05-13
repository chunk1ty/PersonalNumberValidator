using PersonalNumberValidator.Common;

namespace PersonalNumberValidator.Validators
{
    internal interface IValidator
    {
        Result IsValid(string number);

        int Order { get; }
    }
}
