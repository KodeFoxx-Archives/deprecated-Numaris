using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Api.Validation.Numbers;
using Kf.Numaris.Api.Validation.Results;
using Kf.Numaris.Implementations.InszNumber.Specification;

namespace Kf.Numaris.Implementations.InszNumber.Validation
{
    public sealed class InszNumberValidator : NumberValidator<InszNumberSpecification>
    {
        public InszNumberValidator(
            IEnumerable<IFieldValidator<InszNumberSpecification>> fieldValidators,
            IEnumerable<IMultipleFieldsValidator<InszNumberSpecification>> multipleFieldsValidators,
            IEnumerable<IFieldSpecification<InszNumberSpecification>> fieldSpecifications,
            IStringParser<InszNumberSpecification> stringParser = null)
            : base(fieldValidators, multipleFieldsValidators, fieldSpecifications, stringParser)
        { }
    }

    public abstract class FieldWithOnlyDigitsAndPaddedZeroesInFrontValidator<TFieldSpecification>
        : FieldValidator<TFieldSpecification, InszNumberSpecification>
        where TFieldSpecification : IFieldSpecification<InszNumberSpecification>
    {
        protected int MaxLength { get; }
        protected char PaddingCharacter { get; }

        public FieldWithOnlyDigitsAndPaddedZeroesInFrontValidator(int maxLength = 2, char paddingCharacter = '0')
        {
            MaxLength = maxLength;
            PaddingCharacter = paddingCharacter;
        }

        public override IFieldValidationResult<InszNumberSpecification> Validate(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return IsNotValid(nameof(ValidationErrorMessages.CanNotBeBlank));

            if (input.Length > MaxLength)
                return IsNotValid(nameof(ValidationErrorMessages.CanNotBeLargerThanXCharacters), MaxLength.ToString());

            if (input.Any(c => !Char.IsDigit(c)))
                return IsNotValid(nameof(ValidationErrorMessages.CanOnlyConsistOfDigitsInRangeFrom0To9));

            if (input.Length < MaxLength)
                return IsValidWithWarning(nameof(ValidationWarningMessages.DoesNotContainPaddingZeroes));

            return IsValid();
        }
    }

    public sealed class DateOfBirthYearValidator
        : FieldWithOnlyDigitsAndPaddedZeroesInFrontValidator<DateOfBirthYearFieldSpecification>
    {
    }

    public sealed class DateOfBirthMonthValidator
        : FieldWithOnlyDigitsAndPaddedZeroesInFrontValidator<DateOfBirthMonthFieldSpecification>
    {
    }

    public sealed class DateOfBirthDayValidator
        : FieldWithOnlyDigitsAndPaddedZeroesInFrontValidator<DateOfBirthDayFieldSpecification>
    {
    }

    public sealed class DayCounterValidator
        : FieldWithOnlyDigitsAndPaddedZeroesInFrontValidator<DayCounterFieldSpecification>
    {
        public DayCounterValidator() : base(maxLength: 3) { }
    }

    public sealed class CheckDigitsValidator
        : FieldWithOnlyDigitsAndPaddedZeroesInFrontValidator<CheckDigitsFieldSpecification>
    {
    }

    public sealed class CheckDigitsMultipleFieldsValidator : MultipleFieldsValidator<InszNumberSpecification>
    {
        protected override IEnumerable<IFieldSpecification<InszNumberSpecification>> FieldSpecifications
            => new List<IFieldSpecification<InszNumberSpecification>> {
                new DateOfBirthYearFieldSpecification(), new DateOfBirthMonthFieldSpecification(), new DateOfBirthDayFieldSpecification(),
                new DayCounterFieldSpecification(), new CheckDigitsFieldSpecification()
            };

        public override IFieldValidationResult<InszNumberSpecification> Validate(IEnumerable<KeyValuePair<Identifier, string>> input)
        {
            var checkDigitsValue = GetValueForField<CheckDigitsFieldSpecification>(input);
            var numberValue = String.Join("", new[] {
                GetValueForField<DateOfBirthYearFieldSpecification>(input),
                GetValueForField<DateOfBirthMonthFieldSpecification>(input),
                GetValueForField<DateOfBirthDayFieldSpecification>(input),
                GetValueForField<DayCounterFieldSpecification>(input)
            });

            if (!Int32.TryParse(checkDigitsValue, out var checkDigits))
                return IsNotValid<CheckDigitsFieldSpecification>(nameof(ValidationErrorMessages.CanOnlyConsistOfDigitsInRangeFrom0To9));

            if (!Int32.TryParse(numberValue, out var number))
                return IsNotValid<CheckDigitsFieldSpecification>(nameof(ValidationErrorMessages.CanOnlyConsistOfDigitsInRangeFrom0To9));

            var numberMod97For1900 = number % 97;
            if (numberMod97For1900 == checkDigits)
                return IsValid<CheckDigitsFieldSpecification>();

            var numberMod97For2000 = Int32.Parse($"2{number}") % 97;
            if (numberMod97For2000 == checkDigits)
                return IsValid<CheckDigitsFieldSpecification>();

            return IsNotValid<CheckDigitsFieldSpecification>(nameof(ValidationErrorMessages.CheckDigitsDoNotMatch));
        }
    }
}
