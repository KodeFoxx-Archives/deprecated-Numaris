using System.Collections.Generic;
using Kf.Numaris.Api.Parsing.Parsers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Tests.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Api.Validation.Numbers;

namespace Kf.Numaris.Api.Tests.Validation.Numbers
{
    public sealed class FakeNumberValidator : NumberValidator<FakeNumberSpecification>
    {
        public FakeNumberValidator(
            IEnumerable<IFieldValidator<FakeNumberSpecification>> fieldValidators,
            IEnumerable<IFieldSpecification<FakeNumberSpecification>> fieldSpecifications,
            IStringParser<FakeNumberSpecification> stringParser = null)
            : base(fieldValidators, fieldSpecifications, stringParser)
        { }
    }
}
