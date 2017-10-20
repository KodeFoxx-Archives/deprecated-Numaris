using System.Collections.Generic;

namespace Kf.Numaris.Api.Validation.Results
{
    public interface IValidationResult
    {
        bool IsValid { get; }
        IReadOnlyList<IPartialValidationResult> PartialResults { get; }
    }
}
