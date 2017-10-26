using System.Collections.Generic;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Api.Validation.Numbers;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;

namespace Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Validation
{
    public sealed class KdgPersonNumberValidator : NumberValidator<KdgPersonNumberSpecification>
    {
        public KdgPersonNumberValidator(
            IEnumerable<IFieldValidator<KdgPersonNumberSpecification>> fieldValidators,
            IEnumerable<IMultipleFieldsValidator<KdgPersonNumberSpecification>> multipleFieldsValidators,
            IEnumerable<IFieldSpecification<KdgPersonNumberSpecification>> fieldSpecifications,
            IStringParser<KdgPersonNumberSpecification> stringParser = null)
            : base(fieldValidators, multipleFieldsValidators, fieldSpecifications, stringParser)
        { }
    }
}
