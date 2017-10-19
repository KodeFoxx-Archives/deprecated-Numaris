using System.Collections.Generic;

namespace Kf.Numaris.Api.Specifications
{
    public interface INumberSpecification : ISpecification
    {
        IReadOnlyCollection<FieldSpecification> FieldSpecifications { get; }
    }
}