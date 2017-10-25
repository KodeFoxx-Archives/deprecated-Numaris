using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Validation.Results
{
    public interface IPartialValidationResult
    {
        Identifier Identifier { get; }
        bool IsValid { get; }
        string Message { get; }
        bool HasMessage { get; }
    }
}
