using System;
using PersonalNumberValidator.Common;

namespace PersonalNumberValidator.Validators
{
    //P.S Dates after 31.12.2099 are not supported
    internal class DateOfBirthValidator : IValidator
    {
        public Result IsValid(string number)
        {
            int year = int.Parse(number.Substring(0, 2));
            int month = int.Parse(number.Substring(2, 2));
            int day = int.Parse(number.Substring(4, 2));

            try
            {
                if (month > 40)
                {
                    new DateTime(year + 2000, month - 40, day);
                }
                else if (month > 20)
                {
                    new DateTime(year + 1800, month - 20, day);
                }
                else
                {
                    new DateTime(year + 1900, month, day);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return Result.Failure("Invalid date of birth.");
            }

            return Result.Success();
        }

        public int Order { get; } = 1;
    }
}
