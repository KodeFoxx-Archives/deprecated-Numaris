using Kf.Numaris.Api.Common;
using System.Collections.Generic;

namespace Kf.Numaris.Api.Validation.Results
{
    public interface IPartialValidationResult
    {
        Identifier Identifier { get; }
        bool IsValid { get; }
        string Message { get; }
        bool HasMessage { get; }

        IReadOnlyList<string> Parameters { get; }
        bool HasParameters { get; }
    }
}
