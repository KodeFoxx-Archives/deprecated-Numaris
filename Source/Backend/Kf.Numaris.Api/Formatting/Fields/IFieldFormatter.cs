using Kf.Numaris.Api.Common;

namespace Kf.Numaris.Api.Formatting.Fields
{
    public interface IFieldFormatter : IFormatter
    {
        Identifier FieldSpecificationIdentifier { get; }
    }
}
