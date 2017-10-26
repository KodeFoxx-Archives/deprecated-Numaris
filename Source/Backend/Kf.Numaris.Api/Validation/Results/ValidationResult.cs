using System.Collections.Generic;
using System.Linq;

namespace Kf.Numaris.Api.Validation.Results
{    
    public sealed class ValidationResult : IValidationResult
    {
        public bool IsValid => PartialResults.All(pr => pr.IsValid);
        public IReadOnlyList<IPartialValidationResult> PartialResults { get; }

        public ValidationResult(IEnumerable<IPartialValidationResult> partialValidationResults)
            => PartialResults = partialValidationResults?.ToList() ?? new List<IPartialValidationResult>();
    }
}
