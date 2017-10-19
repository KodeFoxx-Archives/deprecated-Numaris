using System.Collections.Generic;
using System.Linq;

namespace Kf.Numaris.Api.Specifications.Builders
{
    public sealed class NumberSpecificationBuilder : SpecificationBuilder<NumberSpecification, NumberSpecificationBuilder>
    {
        private readonly HashSet<FieldSpecification> _fieldSpecifications = new HashSet<FieldSpecification>();

        public NumberSpecificationBuilder WithField(FieldSpecification fieldSpecification)
            => SetField(() => _fieldSpecifications.Add(fieldSpecification));

        public override NumberSpecification Build()
            => new NumberSpecification(_name, _fieldSpecifications.ToList());
    }
}
