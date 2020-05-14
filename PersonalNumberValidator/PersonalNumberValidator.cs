using System;
using System.Collections.Generic;
using System.Linq;
using PersonalNumberValidator.Common;
using PersonalNumberValidator.Validators;

namespace PersonalNumberValidator
{
    public class PersonalNumberValidator
    {
        private readonly IEnumerable<IValidator> _validators;

        public PersonalNumberValidator()
        {
            _validators = new List<IValidator> { new LastDigitValidator(), new DateOfBirthValidator(), new BasicValidator() };
        }

        public Result IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number));
            }

            string trimmedNumber = number.Trim();
            foreach (IValidator validator in _validators.OrderBy(x => x.Order))
            {
                var result = validator.Validate(trimmedNumber);
                if (!result.IsSuccessful)
                {
                    return result;
                }
            }

            return Result.Success();
        }
    }
}
