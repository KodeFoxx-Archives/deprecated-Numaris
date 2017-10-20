using System.Collections.Generic;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;

namespace Kf.Numaris.Implementations.KdgPersonNumber.Numbers
{
    public sealed class KdgNumberFormatter : NumberFormatter<KdgNumberSpecification>
    {
        public KdgNumberFormatter(IEnumerable<IFieldFormatter<KdgNumberSpecification>> fieldFormatters)
            : base(fieldFormatters) { }

        public override string Format(string[] input)
            => $"{FieldFormatters[0].Format(input[0])}-{FieldFormatters[1].Format(input[1])}";
    }
}
