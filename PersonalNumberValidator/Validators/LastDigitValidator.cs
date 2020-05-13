using PersonalNumberValidator.Common;
using PersonalNumberValidator.Extensions;

namespace PersonalNumberValidator.Validators
{
    internal class LastDigitValidator : IValidator
    {
        private readonly short[] Weights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        public Result IsValid(string number)
        {
            var actualLastDigit = int.Parse(number.Substring(9, 1));

            int personalNumberSum = 0;
            for (int i = 0; i <= 8; i++)
            {
                personalNumberSum += number[i].GetDigit() * Weights[i];
            }

            var expectedLastDigit = personalNumberSum % 11;
            if (expectedLastDigit == 10)
            {
                expectedLastDigit = 0;
            }

            return actualLastDigit == expectedLastDigit ? Result.Success() : Result.Failure("Invalid Personal number.");
        }

        public int Order { get; } = 2;
    }
}
