using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Specifications.Numbers;

namespace Kf.Numaris.Api.Formatting.Numbers
{
    public abstract class NumberFormatter<TNumberSpecification> : INumberFormatter<TNumberSpecification>
        where TNumberSpecification : INumberSpecification
    {
        public Identifier Identifier
            => Identifier.For<INumberFormatter<TNumberSpecification>>(GetType());

        public IReadOnlyDictionary<int, IFieldFormatter<TNumberSpecification>> FieldFormatters { get; }

        protected IReadOnlyList<IFieldFormatter<TNumberSpecification>> OrderedFieldFormatters
            => FieldFormatters.OrderBy(ff => ff.Key).Select(ff => ff.Value).ToList();

        protected NumberFormatter(
            IEnumerable<IFieldFormatter<TNumberSpecification>> fieldFormatters,
            IEnumerable<IFieldSpecification<TNumberSpecification>> fieldSpecifications)
        {
            fieldFormatters = fieldFormatters?.ToList() ?? new List<IFieldFormatter<TNumberSpecification>>();

            FieldFormatters = fieldSpecifications
                .OrderBy(fs => fs.Order)
                .ToDictionary(
                    fs => fs.Order,
                    fs => fieldFormatters.Single(f => f.FieldSpecificationIdentifier.Id == fs.Identifier.Id)
                );
        }

        public abstract string Format(string[] input);
    }
}
