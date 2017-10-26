using System;
using System.Diagnostics;
using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Validation.Results
{
    [DebuggerDisplay("{Identifier.Name} {IsValid} {Message}")]
    public class PartialValidationResult : IPartialValidationResult
    {
        public Identifier Identifier => Identifier.For<PartialValidationResult>(GetType());
        public bool IsValid { get; }
        public string Message { get; }
        public bool HasMessage => !String.IsNullOrWhiteSpace(Message);

        public PartialValidationResult(bool isValid, string message = null)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}