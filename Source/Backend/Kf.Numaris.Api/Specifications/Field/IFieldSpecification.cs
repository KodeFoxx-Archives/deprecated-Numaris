using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Specifications.Field
{
    public interface IFieldSpecification<TNumberSpecification> : ISpecification
        where TNumberSpecification : ISpecification
    {
        Identifier NumberSpecificationIdentifier { get; }
        int Order { get; }
    }
}
