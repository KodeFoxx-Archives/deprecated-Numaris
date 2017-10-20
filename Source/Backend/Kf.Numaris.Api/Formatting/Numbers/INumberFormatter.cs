using System.Collections.Generic;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Formatting.Numbers
{
    public interface INumberFormatter<TNumberSpecification> : IFormatter
        where TNumberSpecification : INumberSpecification
    {
        IReadOnlyDictionary<int, IFieldFormatter<TNumberSpecification>> FieldFormatters { get; }
        string Format(string[] input);
    }
}
