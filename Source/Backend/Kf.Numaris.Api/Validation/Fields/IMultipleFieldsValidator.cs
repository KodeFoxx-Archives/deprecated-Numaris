using System.Collections.Generic;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Validation.Fields
{
    public interface IMultipleFieldsValidator<TNumberSepcification>
        where TNumberSepcification : INumberSpecification
    {
        Identifier Identifier { get; }
        IReadOnlyList<Identifier> FieldSpecificationIdentifiers { get; }
    }
}
