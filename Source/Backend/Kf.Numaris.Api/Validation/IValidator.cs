using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Validation
{
    public interface IValidator
    {
        Identifier Identifier { get; }
        IValidationResult Validate();
    }
}
