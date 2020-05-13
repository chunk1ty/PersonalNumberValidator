using System;
using System.Collections.Generic;
using System.Linq;
using PersonalNumberValidator.Common;
using PersonalNumberValidator.Extensions;
using PersonalNumberValidator.Validators;

namespace PersonalNumberValidator
{
    public class PersonalNumberValidator
    {
        private readonly IEnumerable<IValidator> _validators;

        public PersonalNumberValidator()
        {
            _validators = new List<IValidator> { new LastDigitValidator(), new DateOfBirthValidator() };
        }

        public Result IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number));
            }

            string trimmedNumber = number.Trim();
            if (trimmedNumber.Length != 10)
            {
                return Result.Failure("Personal number should be 10 digits.");
            }

            if (!trimmedNumber.IsNumber())
            {
                return Result.Failure("Personal number should contains only digits.");
            }

            foreach (IValidator validator in _validators.OrderBy(x => x.Order))
            {
                var result = validator.IsValid(trimmedNumber);
                if (!result.IsSuccessful)
                {
                    return result;
                }
            }

            return Result.Success();
        }
    }
}
