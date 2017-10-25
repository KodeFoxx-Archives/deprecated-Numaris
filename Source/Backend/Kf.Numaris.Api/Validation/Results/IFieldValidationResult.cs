using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Validation.Results
{
    public interface IFieldValidationResult<TNumberSpecification> : IPartialValidationResult
        where TNumberSpecification : INumberSpecification
    {
        Identifier FieldSpecificationIdentifier { get; }
    }
}
