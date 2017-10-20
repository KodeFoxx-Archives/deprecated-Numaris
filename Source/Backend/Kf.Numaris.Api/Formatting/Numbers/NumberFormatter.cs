using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Formatting.Numbers
{
    public abstract class NumberFormatter<TNumberSpecification> : INumberFormatter
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<INumberFormatter>(GetType());

        protected IReadOnlyList<IFieldFormatter<TNumberSpecification>> FieldFormatters { get; }

        protected NumberFormatter(IEnumerable<IFieldFormatter<TNumberSpecification>> fieldFormatters)
            => FieldFormatters = fieldFormatters?.ToList() ?? new List<IFieldFormatter<TNumberSpecification>>();

        public abstract string Format(string[] input);
    }
}
