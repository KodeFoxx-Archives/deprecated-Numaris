using System.Collections.Generic;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Tests.Specifications.Numbers;

namespace Kf.Numaris.Api.Tests.Formatting.Numbers
{
    public sealed class FakeNumberFormatter : NumberFormatter<FakeNumberSpecification>
    {
        public FakeNumberFormatter(
            IEnumerable<IFieldFormatter<FakeNumberSpecification>> fieldFormatters,
            IEnumerable<IFieldSpecification<FakeNumberSpecification>> fieldSpecifications)
            : base(fieldFormatters, fieldSpecifications) { }

        public override string Format(string[] input)
            => $"{OrderedFieldFormatters[0].Format(input[0])}.{OrderedFieldFormatters[1].Format(input[1])}";
    }
}
