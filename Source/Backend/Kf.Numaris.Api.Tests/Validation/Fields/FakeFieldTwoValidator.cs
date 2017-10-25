using Kf.Numaris.Api.Tests.Specifications.Fields;
using Kf.Numaris.Api.Tests.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Tests.Validation.Fields
{
    public sealed class FakeFieldTwoValidator : FieldValidator<FakeFieldTwoSpecification, FakeNumberSpecification>
    {
        public override IFieldValidationResult<FakeNumberSpecification> Validate(string input)
            => IsValid();
    }
}
