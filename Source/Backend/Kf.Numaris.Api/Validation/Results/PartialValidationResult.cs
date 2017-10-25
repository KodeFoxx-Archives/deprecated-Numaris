using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Validation.Results
{
    public class PartialValidationResult : IPartialValidationResult
    {
        public Identifier Identifier => Identifier.For<PartialValidationResult>(GetType());
        public bool IsValid { get; }

        public PartialValidationResult(bool isValid)
            => IsValid = isValid;
    }
}