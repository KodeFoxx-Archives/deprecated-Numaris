using System;
using System.Collections.Generic;
using System.Diagnostics;
using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Validation.Results
{
    [DebuggerDisplay("{Identifier.Name} {IsValid} {Message}")]
    public class PartialValidationResult : IPartialValidationResult
    {
        public Identifier Identifier => Identifier.For<IPartialValidationResult>(GetType());
        public virtual Identifier FieldSpecificationIdentifier => null;
        public bool HasFieldSpecificiationIdentifier => FieldSpecificationIdentifier != null;
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