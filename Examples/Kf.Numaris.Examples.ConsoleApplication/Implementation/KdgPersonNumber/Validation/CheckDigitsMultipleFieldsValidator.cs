using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Api.Validation.Results;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification.Fields;

namespace Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Validation
{
    public sealed class CheckDigitsMultipleFieldsValidator : MultipleFieldsValidator<KdgPersonNumberSpecification>
    {
        protected override IEnumerable<IFieldSpecification<KdgPersonNumberSpecification>> FieldSpecifications
            => new List<IFieldSpecification<KdgPersonNumberSpecification>>
            {
                new CheckDigitsFieldSpecification(), new PersonNumberFieldSpecification()
            };

        public override IFieldValidationResult<KdgPersonNumberSpecification> Validate(IEnumerable<KeyValuePair<Identifier, string>> input)
        {
            var checkDigitsValue = GetValueForField<CheckDigitsFieldSpecification>(input);
            var personNumberValue = GetValueForField<PersonNumberFieldSpecification>(input);

            if (!Int32.TryParse(checkDigitsValue, out var checkDigits))
                return IsNotValid<CheckDigitsFieldSpecification>("Cannot consist of anything other than digits ranging from 0 to 9");

            if(!Int32.TryParse(personNumberValue, out var personNumber))
                return IsNotValid<PersonNumberFieldSpecification>("Cannot consist of anything other than digits ranging from 0 to 9");

            var personNumberMod97 = personNumber % 97;
            if (personNumberMod97 != checkDigits)
                return IsNotValid<CheckDigitsFieldSpecification>("Has to be mod 97 of the person number");

            return IsValid<CheckDigitsFieldSpecification>();
        }
    }
}
