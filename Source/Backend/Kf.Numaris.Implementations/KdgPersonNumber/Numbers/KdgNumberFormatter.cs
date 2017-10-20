using System.Collections.Generic;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Specifications.Field;

namespace Kf.Numaris.Implementations.KdgPersonNumber.Numbers
{
    public sealed class KdgNumberFormatter : NumberFormatter<KdgNumberSpecification>
    {
        public KdgNumberFormatter(
            IEnumerable<IFieldFormatter<KdgNumberSpecification>> fieldFormatters,
            IEnumerable<IFieldSpecification<KdgNumberSpecification>> fieldSpecifications)
            : base(fieldFormatters, fieldSpecifications) { }

        public override string Format(string[] input)
            => $"{OrderedFieldFormatters[0].Format(input[0])}-{OrderedFieldFormatters[1].Format(input[1])}";
    }
}
