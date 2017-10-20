using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Formatting.Fields
{
    public interface IFieldFormatter<TNumberSpecification> : IFormatter
        where TNumberSpecification : INumberSpecification
    {
        Identifier FieldSpecificationIdentifier { get; }
        string Format(string input);
    }
}
