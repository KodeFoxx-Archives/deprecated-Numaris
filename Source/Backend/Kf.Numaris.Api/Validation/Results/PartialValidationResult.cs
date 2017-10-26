using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public IReadOnlyList<string> Parameters { get; }
        public bool HasParameters => Parameters.Count != 0;

        public PartialValidationResult(bool isValid, string message = null, params string[] parameters)
        {
            IsValid = isValid;
            Message = message;
            Parameters = parameters?.ToList() ?? new List<string>();
        }
    }
}