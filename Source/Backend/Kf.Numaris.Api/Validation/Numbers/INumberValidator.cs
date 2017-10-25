using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Results;

namespace Kf.Numaris.Api.Validation.Numbers
{
    public interface INumberValidator<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        Identifier Identifier { get; }
        IValidationResult Validate(string input);
        IValidationResult Validate(string[] input);
    }
}
