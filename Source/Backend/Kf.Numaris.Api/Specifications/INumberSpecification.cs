using System;
using System.Collections.Generic;

namespace Kf.Numaris.Api.Specifications
{
    public interface INumberSpecification : ISpecification
    {
        Func<string, string[]> ParseAlgorithm { get; }
        IReadOnlyCollection<FieldSpecification> FieldSpecifications { get; }
    }
}