using System.Collections.Generic;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Implementations.InszNumber.Formatting;
using Kf.Numaris.Implementations.InszNumber.Specification;
using Kf.Numaris.Implementations.InszNumber.Validation;

namespace Kf.Numaris.Implementations.Tests.InszNumber
{
    public static class InszNumberTestData
    {
        public static IEnumerable<IFieldSpecification<InszNumberSpecification>> FieldSpecifications =
            new List<IFieldSpecification<InszNumberSpecification>>
            {
                new CheckDigitsFieldSpecification(),
                new DayCounterFieldSpecification(),
                new DateOfBirthYearFieldSpecification(),
                new DateOfBirthMonthFieldSpecification(),
                new DateOfBirthDayFieldSpecification()
            };

        public static IEnumerable<IFieldFormatter<InszNumberSpecification>> FieldFormatters =
            new List<IFieldFormatter<InszNumberSpecification>>
            {
                new DateOfBirthYearFormatter(), new DateOfBirthMonthFormatter(), new DateOfBirthDayFormatter(),
                new CheckDigitsFormatter(), new DayCounterFormatter()
            };

        public static IEnumerable<IFieldValidator<InszNumberSpecification>> FieldValidators =
            new List<IFieldValidator<InszNumberSpecification>> {
                new DateOfBirthYearValidator(), new DateOfBirthMonthValidator(), new DateOfBirthDayValidator(),
                new DayCounterValidator(), new CheckDigitsValidator()
            };
        public static IEnumerable<IMultipleFieldsValidator<InszNumberSpecification>> MultupleFieldsValidators =
            new List<IMultipleFieldsValidator<InszNumberSpecification>> {
                new CheckDigitsMultipleFieldsValidator()
            };
    }
}
