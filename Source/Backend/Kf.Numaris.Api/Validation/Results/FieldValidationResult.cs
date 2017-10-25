using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Validation.Results
{
    public sealed class FieldValidationResult<TFieldSpecification, TNumberSpecification>
        : PartialValidationResult, IFieldValidationResult<TNumberSpecification>
        where TFieldSpecification : IFieldSpecification<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier FieldSpecificationIdentifier
            => Identifier.For<IFieldSpecification<TNumberSpecification>>(typeof(TFieldSpecification));

        public FieldValidationResult(bool isValid)
            : base(isValid)
        { }
    }
}
