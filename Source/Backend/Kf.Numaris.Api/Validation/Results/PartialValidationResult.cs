using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Validation.Results
{
    public abstract class PartialValidationResult : IPartialValidationResult
    {
        public Identifier Identifier => Identifier.For<PartialValidationResult>(GetType());
        public bool IsValid { get; }

        protected PartialValidationResult(bool isValid)
            => IsValid = isValid;
    }
}