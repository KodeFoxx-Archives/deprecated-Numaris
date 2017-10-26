using System.Diagnostics;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Validation.Results
{
    [DebuggerDisplay("{Identifier.Name} for field '{FieldSpecificationIdentifier.Name}'")]
    public sealed class FieldValidationResult<TFieldSpecification, TNumberSpecification>
        : PartialValidationResult, IFieldValidationResult<TNumberSpecification>
        where TFieldSpecification : IFieldSpecification<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public override Identifier FieldSpecificationIdentifier
            => Identifier.For<IFieldSpecification<TNumberSpecification>>(typeof(TFieldSpecification));        

        public FieldValidationResult(bool isValid, string message = null)
            : base(isValid, message)
        { }
    }
}
