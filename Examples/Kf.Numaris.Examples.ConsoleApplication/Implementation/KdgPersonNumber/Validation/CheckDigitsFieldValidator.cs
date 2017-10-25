using System;
using System.Linq;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Api.Validation.Results;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification.Fields;

namespace Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Validation
{
    public sealed class CheckDigitsFieldValidator : FieldValidator<CheckDigitsFieldSpecification, KdgPersonNumberSpecification>
    {
        public override IFieldValidationResult<KdgPersonNumberSpecification> Validate(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return IsNotValid("Cannot be empty or white space");

            if (input.Length > 2)
                return IsNotValid("Cannot be larger than two characters");

            if (input.Any(c => !Char.IsDigit(c)))
                return IsNotValid("Cannot consist of anything other than digits ranging from 0 to 9");

            if (input.Length < 2)
                return IsValidWithWarning("Contains no padding zeroes");

            return IsValid();
        }
    }
}
