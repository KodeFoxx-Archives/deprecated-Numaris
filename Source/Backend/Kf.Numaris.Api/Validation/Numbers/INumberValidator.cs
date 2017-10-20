using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Validation.Numbers
{
    public interface INumberValidator<TNumberSpecification> : IValidator
        where TNumberSpecification : INumberSpecification
    {
    }
}
